using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;
using AirTrafficMonitor.Track;



namespace AirTrafficMonitor.TransponderReceiverClient
{
    public class TrackInAirspaceEvent : EventArgs
    {
        public List<Track.Track> tracks { get; set; }
    }


    public delegate void InformationReceivedHandler(object o, TrackInAirspaceEvent e);

    public interface ITransponderReceiverClient
    {
        event InformationReceivedHandler TrackEventReceived;
    }
}
