﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Track
{
    public class Track
    {
        public string Tag { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int Altitude { get; set; }
        public double HorizontalVelocity { get; set; }
        public double CompassCourse { get; set; }
        public DateTime Timer { get; set; }

        // https://stackoverflow.com/questions/4219261/overriding-operator-how-to-compare-to-null
        // Matching of tags to make sure our tracks never have the same Tag.
        // Attempt 1

        public static bool operator !=(Track t1, Track t2)
        {
            return t1.Tag != t2.Tag;
        }

        public static bool operator ==(Track t1, Track t2)
        {
            if(t1 is null)
            {
                return t2 is null;
            }

            return t1.Tag.Equals(t2.Tag);
        }

    }
}