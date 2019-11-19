using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.TrackHandler;
using TransponderReceiver;

// Raw-data arrives only separated by ';'
// as so: “ATR423;39045;12932;14000;20151006213456789”
//        "Tag;XCoordinate;YCoordinate;Altitude;Timestamp"


namespace AirTrafficMonitor.Data
{
    public class TrackInAirspaceEvent : EventArgs
    {
        public List<Track.Track> tracks { get; set; }
    }

    public delegate void InformationReceivedHandler(object o, TrackInAirspaceEvent e);

    public class DataFormat : IDataFormat
    {
        private ITransponderReceiver receiver;

        public event EventHandler<TransponderDataEventArgs> TransponderDataReady;

        public DataFormat(ITransponderReceiver receiver)
        {
            this.receiver = receiver;
            this.receiver.TransponderDataReady += ReceiverOnTransponderDataReady;
        }

        public void ReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            List<Track.Track> tempTracks = new List<Track.Track>();

            foreach (var data in e.TransponderData)
            {
                Track.Track track = CreateTrack(data);
                tempTracks.Add(track);

                //System.Console.WriteLine($"TransponderData {data}");
            }
            if (TransponderDataReady != null)
            {
                TransponderDataReady(this, new TransponderDataEventArgs { tracks = tempTracks });
            }
        }

        public Track.Track CreateTrack(string trackInfo)
        {
            Track.Track track = new Track.Track();

            string[] trackInfoSplit = trackInfo.Split(';');

            track.Tag = trackInfoSplit[0];
            track.XCoordinate = Convert.ToInt32(trackInfoSplit[1]);
            track.YCoordinate = Convert.ToInt32(trackInfoSplit[2]);
            track.Altitude = Convert.ToInt32(trackInfoSplit[3]);

            string DateFormat = "yyyyMMddHHmmssfff";
            track.Timer = DateTime.ParseExact(trackInfoSplit[4], DateFormat, CultureInfo.InvariantCulture);

            Console.WriteLine(track.Timer);

            return track;

        }
    }
}
