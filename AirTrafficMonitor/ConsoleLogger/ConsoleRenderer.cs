using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.TrackHandler;

namespace AirTrafficMonitor.ConsoleLogger
{
    public class ConsoleRenderer
    {
        private ITrackHandler trackHandler;
        private string _logFile;
        private string _path;


        public ConsoleRenderer(ITrackHandler _trackHandler)
        {
            trackHandler = _trackHandler;
            trackHandler.RaiseEvent += RenderTrackInfo;
        }
        public void RenderTrackInfo(object source, TrackUpdateEvent e)
        {
            _logFile = @"\Log.txt";
            _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + _logFile;
            //StreamWriter sw = new StreamWriter(_path); For some reason we can't acces the path (might not be closed somewhere?)

            Console.Clear();
            foreach (var track in e.ListOfNewTracks)
            {
                Console.WriteLine("New Detection");
                Console.WriteLine("Tag " + track.Tag);
                Console.WriteLine("Current x-cord: {0},  y-cord: {1},  altitude: {2} ", track.XCoordinate, track.YCoordinate, track.Altitude );
                Console.WriteLine("Current horizontal velocity in m/s: {0} and course in degrees: {1} ", track.HorizontalVelocity, track.CompassCourse);
            }
            foreach (var track in e.ListOfUpdatedTracks)
            {
                Console.WriteLine("Updating Tracks in airspace");
                Console.WriteLine("Tag " + track.Tag);
                Console.WriteLine("Current x-cord: {0},  y-cord: {1},  altitude: {2} ", track.XCoordinate, track.YCoordinate, track.Altitude);
                Console.WriteLine("Current horizontal velocity in m/s: {0} and course in degrees: {1} ", track.HorizontalVelocity, track.CompassCourse);
            }

            if (File.Exists(_path))
            {
                foreach (var track in e.ListOfCollidingTracks)
                {
                    Console.WriteLine("COLLISION Detected!");
                    Console.WriteLine("{0} is colliding with {1}", track.New.Tag, track.Old.Tag);
                    //sw.WriteLine("COLLISION Detected!");
                    //sw.WriteLine("{0} is colliding with {1}", track.New.Tag, track.Old.Tag);
                    //sw.Close();

                }
            }
        }
    }
}
