using AirTrafficMonitor.ConditionLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.TrackHandler
{
    public class TrackHandler : ITrackHandler
    {
        private List<Tracks> _tracks;
        private List<string> _trackTags;
        private ITransponderReceiverClient _transponderReceiverClient;


        public TrackHandler(ITransponderReceiverClient TransponderReceiverClient, IConditionLogger conditionLogger)
        {

        }






    }
}
