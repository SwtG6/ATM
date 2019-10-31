using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Transponder
{
    public class RawTransponderDataEventArgs : EventArgs
    {
        public RawTransponderDataEventArgs(List<string> transponderData)
        {
            TransponderData = transponderData;
        }
        public List<string> TransponderData { get; }
    }
    public interface ITransponderReceiver
    {
        event EventHandler<RawTransponderDataEventArgs> TransponderDataReady;

        void HandleTransponderData(object o, RawTransponderDataEventArgs arg);
    }
}
