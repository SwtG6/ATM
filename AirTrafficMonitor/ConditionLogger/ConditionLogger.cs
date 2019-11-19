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
        private readonly List<Tracks> _tracksLogged;
        private string Path;
        private string LogFile;


        // ConditionLogger Constructor sets path to Local AppData and adds a .txt file called Log.
        // if the file already exists it just instantiates the List of Tracks
        public ConditionLogger()
        {
            // removed AppData usage changed to documents. now saved as Log.txt in path: "C:\\Users\\FlemmingBlaabjerg\\Documents\\Log.txt"
            LogFile = @"\Log.txt";
            Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + LogFile;
            if (!File.Exists(Path))
            {
                var fileStream = File.Create(Path);
                fileStream.Close();
            }
            _tracksLogged = new List<Tracks>();
        }

        // LogTracks function: Writes logtext for TrackTags and related Timers
        public void LogTracks(Tracks tracks)
        {
            if (!Logged(tracks))
            {
                File.AppendAllText(Path, $"{tracks.New.Tag};{tracks.Old.Tag};{tracks.New.Timer.ToString()}" + Environment.NewLine);
                _tracksLogged.Add(tracks);
            }
        }

        // Bool function tool needed for if statement, to see if the Tracks are already logged.
        private bool Logged(Tracks tracks)
        {
            return _tracksLogged.Exists(tl => (tl.New == tracks.New && tl.Old == tracks.Old) || (tl.New == tl.Old && tl.Old == tl.New));
        }
    }
}
