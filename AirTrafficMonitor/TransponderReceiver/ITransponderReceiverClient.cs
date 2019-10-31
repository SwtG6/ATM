using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.TransponderReceiver;

namespace Calculator.TransponderReceiver
{
    public class RawTransponderDataEventArgs : EventArgs
    {
        public RawTransponderDataEventArgs(List<Track.Track> transponderData)
        {
            TransponderData = transponderData;
        }

        public List<Track.Track> TransponderData { get; }
    }

    public interface ITransponderReceiver
    {
        event EventHandler<RawTransponderDataEventArgs> TransponderDataReady;

        void HandleTransponderData(object o, RawTransponderDataEventArgs arg);
    }
}
