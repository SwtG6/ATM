using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Data;
using TransponderReceiver;


namespace AirTrafficMonitor.TransponderReceiver
{
    public class TransponderReceiverClient
    {
        private ITransponderReceiver receiver;
        private IDataFormat _dataFormat;
        public event InformationReceivedHandler TrackData;

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

            if (TrackData != null)
            {
                TrackData(this, new TrackInAirspaceEvent { tracks = tempTrack });
            }
        }
    }










    //public class TransponderReceiverClient : ITransponderReceiverClient
    //{
    //    private ITransponderReceiver receiver;

    //    public event EventHandler<TransponderDataEventArgs> TransponderDataReady;


    //    //private ITransponderReceiver _receiver;
    //    //private IDataFormat dataFormat;

    //    public TransponderReceiverClient(ITransponderReceiver receiver /*, IDataFormat dataFormat*/)
    //    {
    //        // This will store the real or the fake transponder data receiver
    //        this.receiver = receiver;


    //        //_receiver = receiver;
    //        //this.dataFormat = dataFormat;

    //        // Attach to the event of the real or the fake TDR
    //        this.receiver.TransponderDataReady += ReceiverOnTransponderDataReady;


    //        //TransponderDataReady += ReceiverOnTransponderDataReady;
    //    }

    //    public void ReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs e)
    //    {
    //        List<Track.Track> tempTracks = new List<Track.Track>();

    //        // Just display data
    //        foreach (var data in e.TransponderData)
    //        {
    //            Track.Track track = CreateTrack(data);
    //            tempTracks.Add(track);

    //            System.Console.WriteLine($"TransponderData {data}");
    //        }
    //        if (TransponderDataReady != null)
    //        {
    //            TransponderDataReady(this, new TransponderDataEventArgs {tracks = tempTracks});
    //        }
    //    }

    //    public Track.Track CreateTrack(string trackInfo)
    //    {
    //        Track.Track track = new Track.Track();

    //        string[] trackInfoSplit = trackInfo.Split(';');

    //        track.Tag = trackInfoSplit[0];
    //        track.XCoordinate = Convert.ToInt32(trackInfoSplit[1]);
    //        track.YCoordinate = Convert.ToInt32(trackInfoSplit[2]);
    //        track.Altitude = Convert.ToInt32(trackInfoSplit[3]);

    //        string DateFormat = "yyyyMMddHHmmssfff";
    //        track.Timer = DateTime.ParseExact(trackInfoSplit[4], DateFormat, CultureInfo.InvariantCulture);

    //        return track;

    //    }
    //}
}
