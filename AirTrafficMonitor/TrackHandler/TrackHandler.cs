using AirTrafficMonitor.ConditionLogger;
using AirTrafficMonitor.TransponderReceiver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

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
            TransponderReceiverClient.TransponderDataReady += AddTrack;
        }

        private void AddNewTrack(Track.Track add)
        {
            Tracks newTrack = new Tracks();
            newTrack.New = add;
            _tracks.Add(newTrack);
        }

        private void UpdateTrack(Track.Track upTrack)
        {
            int trackIndex = _tracks.FindIndex(t => t.New == upTrack);

            _tracks[trackIndex].Old = _tracks[trackIndex].New;

            _tracks[trackIndex].New = upTrack;

            //calculating new course and velocity
            Track.Track track1 = _tracks[trackIndex].Old;
            Track.Track track2 = _tracks[trackIndex].New;

            _tracks[trackIndex].New.CompassCourse = Calculator.Calculator.GetCurrentCourse(track1, track2);

            _tracks[trackIndex].New.HorizontalVelocity = Calculator.Calculator.GetCurrentVelocity(track1, track2);
        }

        private void AddTrack(object sender, TransponderReceiver.TransponderDataEventArgs arg)
        {
            _trackUpdate = new TrackUpdateEvent();

            foreach (var track in arg.tracks)
            {
                if (Calculator.Calculator.TrackIsInsideAirSpace(track))
                {
                    if (!_trackTags.Contains(track.Tag))
                    {
                        _trackTags.Add(track.Tag);
                        AddNewTrack(track);
                        _trackUpdate.ListOfNewTracks.Add(track);
                    }
                    else
                    {
                        UpdateTrack(track);
                        _trackUpdate.ListOfUpdatedTracks.Add(track);
                    }
                }
                else
                {
                    if (_trackTags.Contains(track.Tag))
                    {
                        _trackTags.Remove(track.Tag);
                        _tracks.Remove(_tracks.First(t => t.New.Tag == track.Tag));
                    }
                }
            }

            ArePlanesColliding();

            RaiseEvent?.Invoke(this, _trackUpdate);
        }

        private void ArePlanesColliding()
        {
            for (int i = 0; i < _tracks.Count - 1; i++)
            {
                for (int j = i + 1; j < _tracks.Count; j++)
                {
                    if (Calculator.Calculator.AreTracksColliding(_tracks[i].New,_tracks[j].Old))
                    {
                        Tracks testTracks = new Tracks { New = _tracks[i].New, Old = _tracks[j].Old}
                        if (!_conditionTracks.Contains(testTracks.GetHashCode()))
                        {
                            _trackUpdate.ListOfCollidingTracks.Add(testTracks);
                            _conditionTracks.Add(testTracks.GetHashCode());
                            _conditionLogger.LogTracks(testTracks);
                        }
                        
                    }
                }
            }
        }

        public event UpdateTrack RaiseEvent;

    }
}
