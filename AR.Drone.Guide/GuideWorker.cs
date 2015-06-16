using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;

using AR.Drone.Avionics.Apparatus;
using AR.Drone.Client;
using AR.Drone.Client.Command;
using AR.Drone.Data.Navigation;
using AR.Drone.Infrastructure;
using AR.Drone.Video;
using AR.Drone.Client.Configuration;
using System.Windows.Forms;

namespace AR.Drone.Guide
{
    public enum GuideState
    {
        None,
        Init,
        Takeoff,
        Searching,
        TrackingHover,
        TrackingChase
    }

    class GuideWorker : WorkerBase
    {

        private bool _active;
        public bool Active
        {
            get{
                lock (this)
                {
                    return _active;
                }
            }
            set
            {
                lock (this)
                {
                    _active = value;
                }
            }
        }

        private NavigationData _lastNavData;
        private NavigationData _navData;
        private DroneClient _droneClient;

        public static float TargetDistance = 200; //distance that we want the target to be from the drone
        public static float EmergencyDistance = 500; //distance that results in an emergency landing or backing off (if the drone gets too close)
        public static float MaxTilt = .15f; //max tilt value (between 0.0 and 1.0) that we can use to send to the drone
        public static float MaxVelocity = 2; //maximum velocity we want the drone to go
        public static float ChaseVelocity = 2; //static velocity we want the drone to acheive if we don't have an estimate of how fast the runner is moving
        public static float DetectionTime = .5f; //amount of uninterupted tag detection that we need to progress from 'Searching' to 'tracking'

        public float ElevationTarget = 1.5f;

        public String StateText;

        public bool ShouldFly = true; //just a flag for me to easily test state stuff without actually flying the drone

        public GuideState state = GuideState.None;

        private float _timeSinceLastNavPacket;
        private DateTime _timeLastNavPacketReceived;
        private float _detectionTime; //time since we got a navigation data packet that had tag detection

        private float _targetVelocityX;

        private int _noTagDetectionPackets = 0;

        public float EstRunnerSpeed = 0.0f;

        private int _lastDetectedDistance = 0;

        private float _waitTimer = 0;
        private bool _flatTrimDone = false;

        private Input _thisInput;
        public Input LastInput;
        private bool _shouldSendInput = true;

        public bool LeftPressed = false;
        public bool RightPressed = false;

		private Bitmap _frameBitmap;
		private VideoFrame _frame;
		private uint _frameNumber;

		public Bitmap FrameBitmap
		{
			get { return _frameBitmap; }
		}

        public GuideWorker(DroneClient droneClient)
        {
            _droneClient = droneClient;

            _active = false;
            TurnOnTagDetection();

            //for now...
            _targetVelocityX = ChaseVelocity;
        }

        //Actual driver of the guide drone, not doing anything right now
        protected override void Loop(System.Threading.CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (!Active)
                {
                    Thread.Sleep(10);
                }
                else
                {

                    Thread.Sleep(3);
                }
            }
            
        }

        //Every time we get data from the drone, this is called.
        private void NavigationDataAcquired(NavigationData aPacket)
        {
            LastInput = _thisInput;
            _lastNavData = _navData;

            _timeSinceLastNavPacket = (float)DateTime.Now.Subtract(_timeLastNavPacketReceived).TotalSeconds;
            _timeLastNavPacketReceived = DateTime.Now;

            _navData = aPacket;

            UpdateRunnerVelocity();

            try
            {
                ProcessState();
            }
            catch(Exception e)
            {
                _droneClient.Land();
            }
        }

        private void UpdateRunnerVelocity()
        {
            if (_navData.Vision.nb_detected == 1)
            {
                int dist =  (int)_navData.Vision.dist[0];
                int deltaDist = dist - _lastDetectedDistance;

                EstRunnerSpeed = (float)(deltaDist / _timeSinceLastNavPacket);

                _lastDetectedDistance = dist;
            }
        }

        //Every time the video from the drone is decoded, this is called
        public void VideoPacketDecoded(VideoFrame frame)
        {
			_frame = frame;

			if (_frame == null || _frameNumber == _frame.Number)
				return;
			_frameNumber = _frame.Number;

			if (_frameBitmap == null)
				_frameBitmap = VideoHelper.CreateBitmap(ref _frame);
			else
				VideoHelper.UpdateBitmap(ref _frameBitmap, ref _frame);

			//so many copies, NEED TO OPTIMIZE IF THIS IS SLOW, just trying to get it working right now
			_frameBitmap = ImageUtilities.Threshold(_frameBitmap, 220);



        }


        public void Activate()
        {
            Active = true;
            _droneClient.NavigationDataAcquired += NavigationDataAcquired;
            state = GuideState.Init;
            _waitTimer = 0;
            _flatTrimDone = false;
        }

        /// <summary>Disable autopilot</summary>
        public void Deactivate()
        {
            Active = false;
            _droneClient.NavigationDataAcquired -= NavigationDataAcquired;
        }

        //Send the command to turn on tag detection, currently using the orange-blue-orange pattern (3)
        private void TurnOnTagDetection()
        {
            var configuration = new Settings();
            configuration.Detect.Type = 13;
            configuration.Detect.EnemyColors = 3;

            _droneClient.Send(configuration);
        }

        private void LEDPattern()
        {
            var configuration = new Settings();
            configuration.Leds.LedAnimation = new LedAnimation(LedAnimationType.BlinkGreenRed, 2.0f, 1);
            _droneClient.Send(configuration);
        }

        private void MaintainElevation()
        {
            if (_navData != null)
            {
                if (ElevationTarget - _navData.Altitude > .1)
                {
                    _thisInput.Command = Input.Type.Progress;
                    _thisInput.Gaz = .6f;
                }

            }
        }

        private void AddLeftRight()
        {
            if (LeftPressed)
            {
                _thisInput.Roll = .2f;
                _thisInput.Command = Input.Type.Progress;
            }
            else if (RightPressed)
            {
                _thisInput.Roll = -.2f;
                _thisInput.Command = Input.Type.Progress;

            }
        }

        #region state processing stuff
        //State is only updated by a new navigation packet, since all of its transitions depend on getting new data from navigation packets
        //Might be different if we want to change to a state depending on video, but probably not

        private void ProcessState()
        {
            _thisInput.Reset();
            _thisInput.Command = Input.Type.Hover;
            _shouldSendInput = true;
            switch (state)
            {
                case GuideState.Init:
                    StateText = "Init";
                    StateInit();
                    break;
                case GuideState.Takeoff:
                    StateText = "Takeoff";
                    StateTakeoff();
                    break;
                case GuideState.Searching:
                    StateText = "Searching";
                    StateSearching();
                    break;
                case GuideState.TrackingHover:
                    StateText = "TrackingHover";
                    StateTrackingHover();
                    break;
                case GuideState.TrackingChase:
                    StateText = "TrackingChase";
                    StateTrackingChase();
                    break;
            }
            AddLeftRight();
            if(state != GuideState.Init && _shouldSendInput && ShouldFly)
                _thisInput.Send(_droneClient);
        }

        //Initial state, do a flattrim command, wait a second, then just send the "takeoff" request once and then transitions to taking off
        private void StateInit()
        {
            if (!_flatTrimDone)
            {
                _droneClient.FlatTrim();
            }

            //just going to wait with this super shitty method for a second to make sure the flattrim request goes through and is registered
            _waitTimer += _timeSinceLastNavPacket;

            if (_waitTimer > 1)
            {
                if (ShouldFly)
                {
                    _droneClient.Takeoff();
                }
                state = GuideState.Takeoff;
            }
            _shouldSendInput = false;
        }

        //Here, we wait until we get a navdata packet that indicates that we are done taking off (state should change to hovering eventually)
        //Once we detect that we are flying, we just switch to searching
        private void StateTakeoff()
        {
            if (!_navData.State.HasFlag(NavigationState.Takeoff) && ShouldFly)
            {
                if (_navData.Altitude >= .7)
                    MaintainElevation();
                else
                    _shouldSendInput = false;

                if (_navData.Altitude >= ElevationTarget)
                    state = GuideState.Searching;
            }
            //just for debugging without flying
            else if (!ShouldFly)
            {
                state = GuideState.Searching;
            }
            else
            {

                _shouldSendInput = false;
            }
        }

        //Here we are looking for the packets
        private void StateSearching()
        {
            _thisInput.Command = Input.Type.Hover;
            //while searching, make the stuff flash
            //LEDPattern();
            //gotta find the tag for a couple seconds
            if (_navData.Vision.nb_detected >= 1)
            {
                _detectionTime += (float)_timeSinceLastNavPacket;

                if (_detectionTime >= DetectionTime)
                {
                    state = GuideState.TrackingHover;
                }

            }
            else
            {
                //if no tag detection, crap.
                _detectionTime = 0;
            }
        }

        //Here we are checking to see if the target is within our desired distance.  We'll transition to TrackignChase if we go out of that distance
        private void StateTrackingHover()
        {
            _thisInput.Command = Input.Type.Hover;

            if (_navData.Vision.nb_detected >= 1)
            {
                _noTagDetectionPackets = 0;
                if (_navData.Vision.dist[0] < TargetDistance)
                {
                    state = GuideState.TrackingChase;
                    //trigger the next state action so that we don't have to wait for another navigation packet to actually move
                }
                else
                {
                    
                }
                
            }
            //we lost the tag, don't disable immediately, but go back to searching state if we lose enough packets in a row
            else
            {
                _noTagDetectionPackets += 1;
                if (_noTagDetectionPackets > 30)
                {
                    state = GuideState.Searching;
                }
            }
            
        }

        private void StateTrackingChase()
        {
            if (_navData.Vision.nb_detected >= 1)
            {
                _noTagDetectionPackets = 0;
                //If we are far enough to the target again, switch back to hovering
                if (_navData.Vision.dist[0] >= TargetDistance)
                {
                    state = GuideState.TrackingHover;
                }
                //otherwise, we'll need to move backwards
                else
                {
                    float velX = _navData.Velocity.X;
                    float deltaVelX = _targetVelocityX - Math.Abs(velX);
                    float proportional = deltaVelX / _targetVelocityX;

                    float targetTilt = proportional * MaxTilt;

                    if (velX > MaxVelocity)
                    {
                        targetTilt = 0;
                    }

                    if (targetTilt > MaxTilt)
                    {
                        targetTilt = MaxTilt;
                    }

                    _thisInput.Command = Input.Type.Progress;
                    _thisInput.Pitch = .1f; //using a static backwards value for now.

                }
            }
            //we lost the tag, don't disable immediately, but go back to searching state if we lose enough packets in a row
            else
            {
                _noTagDetectionPackets += 1;
                if (_noTagDetectionPackets > 30)
                {
                    state = GuideState.Searching;
                }

            }
        }

        #endregion

    }
}
