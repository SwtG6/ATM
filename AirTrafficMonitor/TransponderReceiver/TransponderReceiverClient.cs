using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Data;
using TransponderReceiver;


namespace AirTrafficMonitor.TransponderReceiverClient
{

    public class TransponderReceiver : ITransponderReceiver
    {
        private ITransponderReceiver receiver;
        private IDataFormat _dataFormat;

        public event EventHandler<RawTransponderDataEventArgs> TransponderDataReady;


        public TransponderReceiver(ITransponderReceiver receiver, IDataFormat dataFormat)
        {
            // This will store the real or the fake transponder data receiver
            this.receiver = receiver;
            _dataFormat = dataFormat;

            // Attach to the event of the real or the fake TDR
            this.receiver.TransponderDataReady += ReceiverOnTransponderDataReady;
        }
 
        private void ReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            List<Track.Track> tempTracks = new List<Track.Track>();

            // Just display data
            foreach (var data in e.TransponderData)
            {
                tempTracks.Add(_dataFormat.CreateTrack(data));
                System.Console.WriteLine($"Transponderdata {data}");
            }
            if (TransponderDataReady != null)
            {
                TransponderDataReady(this, new RawTransponderDataEventArgs{tracks = tempTracks});
            }

        }




        ////private ITransponderReceiver dataReceiver;
        ////private IDataFormat _dataFormatter;

        ////public event RawTransponderDataEventArgs TransponderDataReady;

        ////public TransponderReceiver(ITransponderReceiver dataReceiver, IDataFormat dataFormatter)
        ////{
        ////    this.dataReceiver = dataReceiver;
        ////    _dataFormatter = dataFormatter;

        ////    this.dataReceiver.TransponderDataReady += HandleTransponderData;
        ////}

        //public void HandleTransponderData(object o, TransponderDataEvent arg)
        //{
        //    List<Track.Track> tempTracks = new List<Track.Track>();

        //    //var list = arg.TransponderData.Select(track => _dataFormatter.CreateTrack(track)).ToList();

        //    foreach (var data in arg.TransponderData)
        //    {
        //        tempTracks.Add(_dataFormatter.CreateTrack(data));

        //        //list.Add(_dataFormatter.CreateTrack(transponderData));
        //    }

        //    if (TransponderDataReady != null)
        //    {
        //        TransponderDataReady(this, new TransponderDataEvent{tracks = tempTracks});
        //    }

        //}

    }

}
