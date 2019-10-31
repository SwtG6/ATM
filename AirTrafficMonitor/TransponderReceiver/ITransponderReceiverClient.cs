using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.TransponderReceiverClient
{
    public class RawTransponderDataEventArgs : EventArgs
    {
        public List<Track.Track> tracks { get; set; }


        //public RawTransponderDataEventArgs(List<string> transponderData)
        //{
        //    this.TransponderData = transponderData;
        //}


        public List<string> TransponderData { get; }
    }

    public delegate void TransponderDataEvent(object o, RawTransponderDataEventArgs arg);
    public interface ITransponderReceiver
    {
        event EventHandler<RawTransponderDataEventArgs> TransponderDataReady;

        //void HandleTransponderData(object o, RawTransponderDataEventArgs arg);
    }
}
