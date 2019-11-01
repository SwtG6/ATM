using AirTrafficMonitor.TrackHandler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.ConditionLogger
{
    public class ConditionLogger : IConditionLogger
    {
        private List<Tracks> TracksLogged;
        private string Path;


        // ConditionLogger Constructor sets path to Local AppData and adds a .txt file called Log.
        // if the file already exists it just instantiates the List of Tracks
        public ConditionLogger()
        {
            // https://stackoverflow.com/questions/2501167/what-directories-do-the-different-application-specialfolders-point-to-in-windows
            Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Log.txt";
            if (!File.Exists(Path))
            {
                var filePath = File.Create(Path);
                filePath.Close();
            }
            TracksLogged = new List<Tracks>();
        }

        // LogTracks function: Writes logtext for TrackTags and related Timers
        public void LogTracks(Tracks tracks)
        {
            if (!Logged(tracks))
            {
                File.AppendAllText(Path, $"{tracks.New.Tag};{tracks.Old.Tag};{tracks.New.Timer.ToString()}" + Environment.NewLine);
                TracksLogged.Add(tracks);
            }
        }

        // Bool function tool needed for if statement, to see if the Tracks are already logged.
        private bool Logged(Tracks tracks)
        {
            return TracksLogged.Exists(tl => (tl.New == tracks.New && tl.Old == tracks.Old) || (tl.New == tl.Old && tl.Old == tl.New));
        }
    }
}
