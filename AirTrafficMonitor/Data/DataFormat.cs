using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

// Raw-data arrives only separated by ';'
// as so: “ATR423;39045;12932;14000;20151006213456789”
//        "Tag;XCoordinate;YCoordinate;Altitude;Timestamp"


namespace AirTrafficMonitor.Data
{
    public class DataFormat : IDataFormat
    {

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

            return track;
        }

    }
}
