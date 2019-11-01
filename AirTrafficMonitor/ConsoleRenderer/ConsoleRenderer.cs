using System;

namespace AirTrafficMonitor.ConsoleRenderer
{
    public class ConsoleRenderer 
    {
        public void OnDataReceived(object source, TrackUpdaEvents e)
        {
            Console.Clear();
            Console.WriteLine("Tag " + e.Track.Tag);
            Console.WriteLine("Current position x-y in meters " + e.Track.Position);
            Console.WriteLine("Current altitude in meters " + e.Track.Altitude);
            Console.WriteLine("Current horizontal velocity in m/s " + e.Track.Velocity);
            Console.WriteLine("Current compass course 0-359 degrees " + e.Track.Course);
            //, clockwise, 0 degrees is north "
            foreach (var VARIABLE in COLLECTION)
            {
                
            }
        }

    }
}