using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Data
{
    public interface IDataFormat
    {
        Track.Track CreateTrack(string trackInfo);
    }
}
