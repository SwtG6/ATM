using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace AirTrafficMonitor.TransponderReceiver
{
    public class TransponderDataEventArgs : EventArgs
    {
        public List<Track.Track> tracks = new List<Track.Track>();


        //public RawTransponderDataEventArgs(List<string> transponderData)
        //{
        //    this.TransponderData = transponderData;
        //}


        //public List<string> TransponderData { get; }
    }

    //public delegate void TransponderDataEvent(object sender, RawTransponderDataEventArgs e);
    public interface ITransponderReceiverClient
    {
        event EventHandler<TransponderDataEventArgs> TransponderDataReady;

        void ReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs e);

        Track.Track CreateTrack(string trackInfo);
    }
}
