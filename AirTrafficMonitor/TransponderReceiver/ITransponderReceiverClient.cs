using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Calculator.TransponderReceiver;

namespace Calculator.TransponderReceiver
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

    public delegate void TransponderDataEvent(object sender, RawTransponderDataEventArgs e);
    public interface ITransponderReceiverClient
    {
        event EventHandler<RawTransponderDataEventArgs> TransponderDataReady;

        void ReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs e);
    }
}
