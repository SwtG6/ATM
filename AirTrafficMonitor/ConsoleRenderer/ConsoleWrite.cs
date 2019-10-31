using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleRendering
{
    public class ConsoleWrite
    {
        public void OnDataReceived(object source, PlaneEventsArgs e)
        {
            Console.WriteLine("Tag " + e.Plane.Tag);
            Console.WriteLine("Current position x-y in meters " + e.Plane.Position);
            Console.WriteLine("Current altitude in meters " + e.Plane.Altitude);
            Console.WriteLine("Current horizontal velocity in m/s " + e.Plane.Velocity);
            Console.WriteLine("Current compass course 0-359 degrees " + e.Plane.Course);
            //, clockwise, 0 degrees is north "
            Console.ReadKey();
        }

    }
}