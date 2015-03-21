using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AR.Drone.Avionics.Objectives.IntentObtainers;
using AR.Drone.Client;
using AR.Drone.Client.Command;
using AR.Drone.Data;
using AR.Drone.Data.Navigation;

namespace AR.Drone.Guide
{
    public class GuideRunner
    {
        public string State = "None";

        private bool _active = false;

        private DateTime _timeLastNavDataPacket;
        private TimeSpan _deltaTime;

        private NavigationData _navData;

        private DroneClient _droneClient;

        private float _velocityEstimate = 0;
        private int _lastDist = 0;

        private int _distThreshold = 300; //centimeters

        public GuideRunner(DroneClient droneClient)
        {
            _droneClient = droneClient;
        }


        public void Activate()
        {
            _active = true;
            _droneClient.NavigationDataAcquired += NavigationDataAcquired;
        }

        public void Deactivate()
        {
            _active = false;
            _droneClient.NavigationDataAcquired -= NavigationDataAcquired;
        }

        private void NavigationDataAcquired(NavigationData aPacket)
        {
            //get time since last packet
            _deltaTime = DateTime.Now.Subtract(_timeLastNavDataPacket);
            _timeLastNavDataPacket = DateTime.Now;

            //If we detect tags:
            if (aPacket.Vision.nb_detected > 0)
            {
                //update velocity and distance info
                int curDist = (int) aPacket.Vision.dist[0];
                float deltaDist = curDist - _lastDist;

                _velocityEstimate = deltaDist/_deltaTime.Milliseconds * 1000; // centimeters/second

                _lastDist = curDist;

                Console.Out.WriteLine("Velocity: " + _velocityEstimate.ToString());

                //drone is close and stuff
                if (curDist < _distThreshold)
                {
                    State = "Moving backwards";
                    Console.Out.Write("Dist: " + curDist.ToString() + " Now Moving Backwards");
                    //_droneClient.Progress(FlightMode.Progressive, pitch: 0.05f);
                }
                else
                {
                    State = "Hovering";
                    Console.Out.Write("Dist: " + curDist.ToString() + " Now Hovering");
                    //_droneClient.Hover();
                }

            }
            
        }
    }
}
