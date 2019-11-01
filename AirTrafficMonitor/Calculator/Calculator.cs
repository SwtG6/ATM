using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Track;

namespace AirTrafficMonitor.Calculator
{
    public static class Calculator
    {

        //Punkt 1&5 - Bruges til at validere om tracks er indenfor airspace
        public static bool TrackIsInsideAirSpace(Track.Track track)
        {
            if ((track.XCoordinate >= 10000 && track.XCoordinate <= 90000) &&
                (track.YCoordinate >= 10000 && track.YCoordinate <= 90000) &&
                (track.Altitude >= 500 && track.Altitude <= 20000))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Punkt 7 - current velocity
        public static double GetCurrentVelocity(Track.Track track1, Track.Track track2)
        {
            double time = (track2.Timer - track1.Timer).Seconds;


            return GetDistance(track1, track2)/time;
        }

        public static double GetDistance(Track.Track track1, Track.Track track2)
        {
            var deltaX = track2.XCoordinate - track1.XCoordinate;
            var deltaY = track2.YCoordinate - track1.YCoordinate;

            return Math.Sqrt((Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2)));
        }

        public static double GetAltitudeDistance(int alt1, int alt2)
        {
            return Math.Abs(alt1 - alt2);
        }

        //Punkt 7 - current course
        public static double GetCurrentCourse(Track.Track track1, Track.Track track2)
        {
            int deltaX = track2.XCoordinate - track1.XCoordinate;
            int deltaY = track2.YCoordinate - track1.YCoordinate;

            var theta = Math.Atan2(deltaX, deltaY);

            var angle = ((theta * 180 / Math.PI) + 360 % 360);

            if (angle < 0)
            {
                angle = 360 + angle;
            }

            return Math.Round(angle,1);

        }


        //Punkt 12 - separation condition
        public static bool AreTracksColliding(Track.Track track1, Track.Track track2)
        {
            if (GetDistance(track1, track2) < 5000 && 
                GetAltitudeDistance(track1.Altitude, track2.Altitude) < 300 )
            {
                return true; //conflicting
            }
            else
            {
                return false; // not conflicting
            }
        }


    }
}
