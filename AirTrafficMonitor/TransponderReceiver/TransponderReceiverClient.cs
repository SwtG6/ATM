using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Data;
using TransponderReceiver;
using RawTransponderDataEventArgs = TransponderReceiver.RawTransponderDataEventArgs;


namespace AirTrafficMonitor.TransponderReceiver
{

    public class TransponderReceiverClient : ITransponderReceiverClient
    {
        private ITransponderReceiver _receiver;
        private IDataFormat _dataFormat;

        public event EventHandler<RawTransponderDataEventArgs> TransponderDataReady;


        public TransponderReceiverClient(ITransponderReceiver receiver, IDataFormat dataFormat)
        {
            // This will store the real or the fake transponder data receiver
            // this.receiver = receiver;
            _receiver = receiver;
            _dataFormat = dataFormat;

            // Attach to the event of the real or the fake TDR
            //this.receiver.TransponderDataReady += ReceiverOnTransponderDataReady;
            TransponderDataReady += ReceiverOnTransponderDataReady;
        }

        public void ReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            List<Track.Track> tempTracks = new List<Track.Track>();

            // Just display data
            foreach (var data in e.TransponderData)
            {
                tempTracks.Add(_dataFormat.CreateTrack(data));
                System.Console.WriteLine($"TransponderData {data}");
            }
            if (TransponderDataReady != null)
            {
                TransponderDataReady(this, new RawTransponderDataEventArgs { tracks = tempTracks });
            }

        }


    }

}
