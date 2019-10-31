﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Calculator
{
    public static class Calculator
    {

        //Punkt 1&5 - Bruges til at validere om tracks er indenfor airspace
        public static bool TrackIsInsideAirSpace(Track track)
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
        public static double GetCurrentVelocity(Track track1, Track track2)
        {
            int deltaX = track2.XCoordinate - track1.XCoordinate;
            int deltaY = track2.YCoordinate - track1.YCoordinate;
            double time = (track2.Timer - track1.Timer).TotalMilliseconds;


            return Math.Sqrt((Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2)))/time/1000;
        }

        //Punkt 7 - current course
        public static double GetCurrentCourse(Track track1, Track track2)
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




    }
}
