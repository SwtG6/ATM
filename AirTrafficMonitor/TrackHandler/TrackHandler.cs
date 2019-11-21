using AirTrafficMonitor.ConditionLogger;
using AirTrafficMonitor.TransponderReceiver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Data;
using TransponderReceiver;
using AirTrafficMonitor.TransponderReceiverClient;

namespace AirTrafficMonitor.TrackHandler
{
    public class TrackHandler : ITrackHandler
    {
        private List<Tracks> tracks;
        private List<string> trackTags;
        private List<int> conditionTracks;
        private ITransponderReceiverClient receiverClient;
        private IConditionLogger conditionLogger;
        private TrackUpdateEvent trackUpdate;
        public int deltaX;
        public int deltaY;


        public TrackHandler(ITransponderReceiverClient _receiverClient, IConditionLogger conditionLog)
        {
            tracks = new List<Tracks>();
            trackTags = new List<string>();
            conditionTracks = new List<int>();
            receiverClient = _receiverClient;
            conditionLogger = conditionLog;
            receiverClient.TrackEventReceived += AddTrack;
        }

        public void AddNewTrack(Track.Track add)
        {
            Tracks newTrack = new Tracks();
            newTrack.New = add;
            tracks.Add(newTrack);
        }

        private void UpdateTrack(Track.Track upTrack)
        {
            int trackIndex = tracks.FindIndex(t => t.New == upTrack);

            tracks[trackIndex].Old = tracks[trackIndex].New;

            tracks[trackIndex].New = upTrack;

            //calculating new course and velocity
            Track.Track track1 = tracks[trackIndex].Old;
            Track.Track track2 = tracks[trackIndex].New;

            tracks[trackIndex].New.CompassCourse = Calculator.Calculator.GetCurrentCourse(track1, track2);

            tracks[trackIndex].New.HorizontalVelocity = Calculator.Calculator.GetCurrentVelocity(track1, track2);
        }

        private void AddTrack(object sender, TrackInAirspaceEvent arg)
        {
            trackUpdate = new TrackUpdateEvent();

            foreach (var track in arg.tracks)
            {
                if (Calculator.Calculator.TrackIsInsideAirSpace(track))
                {
                    if (trackTags.Contains(track.Tag))
                    {
                        UpdateTrack(track);
                        trackUpdate.ListOfUpdatedTracks.Add(track);
                    }
                    else
                    {
                        trackTags.Add(track.Tag);
                        AddNewTrack(track);
                        trackUpdate.ListOfNewTracks.Add(track);
                    }
                }
                else
                {
                    if (trackTags.Contains(track.Tag))
                    {
                        trackTags.Remove(track.Tag);
                        tracks.Remove(tracks.First(t => t.New.Tag == track.Tag));
                    }
                }
            }

            AreTracksColliding();

            RaiseEvent?.Invoke(this, trackUpdate);
        }

        private void AreTracksColliding()
        {
            for (int i = 0; i < tracks.Count - 1; i++)
            {
                for (int j = i + 1; j < tracks.Count; j++)
                {
                    if (Calculator.Calculator.AreTracksColliding(tracks[i].New,tracks[j].Old))
                    {
                        Tracks testTracks = new Tracks {New = tracks[i].New, Old = tracks[j].Old};
                        if (!conditionTracks.Contains(testTracks.GetHashCode()))
                        {
                            trackUpdate.ListOfCollidingTracks.Add(testTracks);
                            conditionTracks.Add(testTracks.GetHashCode());
                            conditionLogger.LogTracks(testTracks);
                        }
                        
                    }
                }
            }
        }

        public event UpdateTrack RaiseEvent;

    }
}
