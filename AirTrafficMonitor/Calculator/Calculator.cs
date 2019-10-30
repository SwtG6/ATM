using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Calculator
{
    public static class Calculator
    {

        //Punkt 5
        public static bool IsInsideAirSpace(int xpos, int ypos)
        {
            return (xpos >= 10000 && xpos <= 90000) && (ypos >= 10000 && ypos <= 90000);
        }
    }
}
