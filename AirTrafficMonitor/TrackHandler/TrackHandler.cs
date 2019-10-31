using AirTrafficMonitor.ConditionLogger;
using AirTrafficMonitor.TransponderReceiverClient;
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
        private List<int> _conditionTracks;
        private ITransponderReceiverClient _transponderReceiverClient;
        private IConditionLogger _conditionLogger;
        private TrackUpdateEvent _trackUpdate;



        public TrackHandler(ITransponderReceiverClient TransponderReceiverClient, IConditionLogger ConditionLogger)
        {
            _tracks = new List<Tracks>();
            _trackTags = new List<string>();
            _conditionTracks = new List<int>();
            _transponderReceiverClient = TransponderReceiverClient;
            _conditionLogger = ConditionLogger;
            TransponderReceiverClient.TransponderDataReady += _addTrack;
        }

        private void _addTrack(object sender, RawTransponderDataEventArgs e)
        {
            _trackUpdate = new TrackUpdateEvent();


        }










        public event UpdateTrack RaiseEvent;

    }
}
