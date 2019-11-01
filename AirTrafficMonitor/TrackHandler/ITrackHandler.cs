using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.TrackHandler
{
    public interface ITrackHandler
    {
        event UpdateTrack RaiseEvent;

    }


    // Tracks distinction between new incoming tracks and old tracks
    public class Tracks
    {
        public  Track.Track New { get; set; }
        public Track.Track Old { get; set; }

    }

    // Delegate for updating tracks via updatetrack event
    public delegate void UpdateTrack(object sender, TrackUpdateEvent e);

    public class TrackUpdateEvent
    {
        public List<Track.Track> ListOfNewTracks { get; set; } = new List<Track.Track>();
        public List<Track.Track> ListOfUpdatedTracks { get; set; } = new List<Track.Track>();
        public List<Tracks> ListOfCollidingTracks { get; set; } = new List<Tracks>();
    }


}
