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
        
        #region TrackIsInsideAirSpace
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

        #endregion

        #region GetCurrentVelocity
        //Region Punkt 7 - current velocity

        public static double GetCurrentVelocity(Track.Track track1, Track.Track track2)
        {
            double time = (track2.Timer - track1.Timer).Seconds;


            return GetDistance(track1, track2)/time;
        }
        #endregion

        #region GetDistance
        public static double GetDistance(Track.Track track1, Track.Track track2)
        {
            // for some reason our application runs and then arrives to this point (to be specific - Track.Track track2 returns a null pointer and crashes the application)
         
            return Math.Sqrt((Math.Pow((track2.XCoordinate - track1.XCoordinate), 2) + Math.Pow(track2.YCoordinate - track1.YCoordinate, 2)));
        }
        #endregion

        #region GetAltitudeDistance
        public static double GetAltitudeDistance(int alt1, int alt2)
        {
            return Math.Abs(alt1 - alt2);
        }
        #endregion
        
        #region GetCurrentCourse
        //Punkt 7 - current course

        public static double GetCurrentCourse(Track.Track track1, Track.Track track2)
        {
           
            var theta = Math.Atan2((track2.XCoordinate - track1.XCoordinate), (track2.YCoordinate - track1.YCoordinate));

            var angle = ((theta * 180 / Math.PI) + 360 % 360);

            if (angle < 0)
            {
                angle = 360 + angle;
            }

            return Math.Round(angle,1);

        }
        #endregion

        #region AreTracksColliding
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
        #endregion

    }
}
