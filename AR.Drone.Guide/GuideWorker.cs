using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AR.Drone.Avionics.Objectives;
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

        public float TargetDistance = 1800; //distance that we want the target to be from the drone
        public float EmergencyDistance = 500; //distance that results in an emergency landing or backing off (if the drone gets too close)
        public float MaxTilt = .05f; //max tilt value (between 0.0 and 1.0) that we can use to send to the drone
        public float MaxVelocity = 2; //maximum velocity we want the drone to go
        public float ChaseVelocity = 2; //static velocity we want the drone to acheive if we don't have an estimate of how fast the runner is moving
        public float DetectionTime = 1; //amount of uninterupted tag detection that we need to progress from 'Searching' to 'tracking'

        public float ElevationTarget = 1.5f;

        public String StateText;


        public GuideState state = GuideState.None;

        private double _timeSinceLastNavPacket;
        private DateTime _timeLastNavPacketReceived;
        private float _detectionTime; //time since we got a navigation data packet that had tag detection

        private float _targetVelocityX;

        private int _noTagDetectionPackets = 0;

        public float EstRunnerSpeed = 0.0f;

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
            _lastNavData = _navData;

            _timeSinceLastNavPacket = DateTime.Now.Subtract(_timeLastNavPacketReceived).TotalSeconds;
            _timeLastNavPacketReceived = DateTime.Now;

            _navData = aPacket;
            try
            {
                ProcessState();
            }
            catch(Exception e)
            {
                _droneClient.Land();
            }
        }

        //Every time the video from the drone is decoded, this is called
        public void VideoPacketDecoded(VideoFrame frame)
        {
            
        }


        public void Activate()
        {
            Active = true;
            _droneClient.NavigationDataAcquired += NavigationDataAcquired;
            state = GuideState.Init;
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

        #region state processing stuff
        //State is only updated by a new navigation packet, since all of its transitions depend on getting new data from navigation packets
        //Might be different if we want to change to a state depending on video, but probably not

        private void ProcessState()
        {
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
        }

        //Initial state, just sends the "takeoff" request once and then transitions to taking off
        private void StateInit()
        {
            //_droneClient.Takeoff();
            state = GuideState.Takeoff;
        }

        //Here, we wait until we get a navdata packet that indicates that we are done taking off (state should change to hovering eventually)
        //Once we detect that we are flying, we just switch to searching
        private void StateTakeoff()
        {
            //if (_navData.Altitude >= ElevationTarget)
           // {
                LEDPattern();
                state = GuideState.Searching;
           // }
        }

        //Here we are looking for the packets
        private void StateSearching()
        {
            //while searching, make the stuff flash
            LEDPattern();
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
            if (_navData.Vision.nb_detected >= 1)
            {
                if (_navData.Vision.dist[0] < TargetDistance)
                {
                    _noTagDetectionPackets = 0;
                    state = GuideState.TrackingChase;
                    //trigger the next state action so that we don't have to wait for another navigation packet to actually move
                    StateTrackingChase();
                }
                //we lost the tag, don't disable immediately, but go back to searching state if we lose enough packets in a row
                else
                {
                    _noTagDetectionPackets += 1;
                    if (_noTagDetectionPackets > 10)
                    {
                        state = GuideState.Searching;
                    }
                    //_droneClient.Hover();
                }
            }
        }

        private void StateTrackingChase()
        {
            if (_navData.Vision.nb_detected >= 1)
            {
                //If we are far enough to the target again, switch back to hovering
                if (_navData.Vision.dist[0] >= TargetDistance)
                {
                    state = GuideState.TrackingHover;
                    //_droneClient.Hover();
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

                    //_droneClient.Progress(FlightMode.Progressive, pitch: targetTilt);

                }
            }
        }

        #endregion

    }
}
