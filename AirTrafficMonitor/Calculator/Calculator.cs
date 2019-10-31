using System;
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




    }
}
