using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace AirTrafficMonitor.Data
{
    //public class TransponderDataEventArgs : EventArgs
    //{
    //    public List<Track.Track> tracks = new List<Track.Track>();
    //}

    public interface IDataFormat
    {
        //event EventHandler<TransponderDataEventArgs> TransponderDataReady;

        //void ReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs e);

        Track.Track CreateTrack(string trackInfo);
    }
}
