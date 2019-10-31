using AirTrafficMonitor.TrackHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.ConditionLogger
{
    public interface IConditionLogger
    {
        void LogTracks(Tracks tracks);
    }
}
