using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.TrackHandler
{
    public interface ITrackHandler
    {



    }

    public class Tracks
    {
        public  Track.Track New { get; set; }
        public Track.Track Old { get; set; }

    }
}
