using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Data;
using AirTrafficMonitor.TransponderReceiverClient;
using TransponderReceiver;


namespace AirTrafficMonitor.TransponderReceiver
{
    public class TransponderReceiverClient : ITransponderReceiverClient
    {
        private ITransponderReceiver receiver;
        private IDataFormat _dataFormat;

        public event InformationReceivedHandler TrackEventReceived;

        // Using constructor injection for dependency/ies
        public TransponderReceiverClient(ITransponderReceiver receiver, IDataFormat dataFormat)
        {
            _dataFormat = dataFormat;
            // This will store the real or the fake transponder data receiver
            this.receiver = receiver;

            // Attach to the event of the real or the fake TDR
            this.receiver.TransponderDataReady += ReceiverOnTransponderDataReady;
        }

        private void ReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            List<Track.Track> tempTrack = new List<Track.Track>();
            // Just display data
            foreach (var data in e.TransponderData)
            {
                tempTrack.Add(_dataFormat.CreateTrack(data));
                //System.Console.WriteLine($"Transponderdata {data}");
            }

            if (TrackEventReceived != null)
            {
                TrackEventReceived(this, new TrackInAirspaceEvent { tracks = tempTrack });
            }
        }
    }
}
