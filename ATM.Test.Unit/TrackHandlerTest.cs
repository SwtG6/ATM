using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.ConditionLogger;
using AirTrafficMonitor.Data;
using AirTrafficMonitor.Track;
using AirTrafficMonitor.TrackHandler;
using AirTrafficMonitor.Calculator;
using AirTrafficMonitor.TransponderReceiver;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;
using AirTrafficMonitor.TransponderReceiverClient;

namespace ATM.Test.Unit
{

    [TestFixture]
    class TrackHandlerTest
    {
        private List<Track> ListOfNewTracks = new List<Track>();
        private List<Track> ListOfUpdatedTracks = new List<Track>();

        private List<Tracks> collisionTracks = new List<Tracks>();

        private TrackHandler uut;
        private ITransponderReceiverClient tr_interface;
        private IConditionLogger logger;

        [SetUp]
        public void Setup()
        {
            tr_interface = Substitute.For<ITransponderReceiverClient>();
            logger = new ConditionLogger();
            uut = new TrackHandler(tr_interface, logger);
            uut.RaiseEvent += RaiseEventHandler;
        }

        private void RaiseEventHandler(object sender, TrackUpdateEvent e)
        {
            ListOfNewTracks = e.ListOfNewTracks;
            ListOfUpdatedTracks = e.ListOfUpdatedTracks;
            collisionTracks = e.ListOfCollidingTracks;
        }

        [Test] // Tag
        public void TrackTest()
        {
            Track tx = new Track
            {
                Altitude = 30000,
                Tag = "ABC1337"
            };

            Track ty = new Track
            {
                Altitude = 12500,
                Tag = "ABC1337"
            };

            Assert.That(tx == ty,Is.True);

                ty.Tag = "XYZ742";

                Assert.That(tx != ty, Is.True);

        }
        
        // [SetUp] // Adding a track

        // https://stackoverflow.com/questions/7068843/how-to-use-datetime-parse-to-create-a-datetime-object/7068890
        public DateTime Parse(string time)
        {
            return DateTime.ParseExact(time, "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
        }

        public List<Track> AddTracks()
        {
            List<Track> track1 = new List<Track>();
            track1.Add(new Track
            {
                Altitude = 10000,
                Tag = "ABC1337",
                Timer = Parse("20191120124030200"),
                XCoordinate = 6666,
                YCoordinate = 6969
            });
            track1.Add(new Track
            {
                Altitude = 12000,
                Tag = "DEF1234",
                Timer = Parse("20191120124030400"),
                XCoordinate = 20000,
                YCoordinate = 10000
            });

            return track1;
        }

        [Test] // Add New Track
        public void AddTrackTest()
        {
            List<Track> track1 = AddTracks();
            tr_interface.TrackEventReceived += Raise.Event<InformationReceivedHandler>
                (this, new TrackInAirspaceEvent { tracks = track1 });

            //Assert.That(ListOfNewTracks, Is.EqualTo(track1));
            Assert.That(ListOfNewTracks, Is.Not.Empty);
        }

        //[Test] // Tag
        //public void TagTest()
        //{
        //    List<Track> tl1 = AddTracks();
        //    tr_interface.TrackEventReceived += Raise.Event<InformationReceivedHandler>
        //        (this, new TrackInAirspaceEvent { tracks = tl1 });

        //    Assert.That(tracks1[0],Is.EqualTo(tl1[0]));
        //}

        //[Test] // Update
        //public void UpdateTrackTest()
        //{
        //    List<Track> tl1 = AddTracks();
        //    tr_interface.TrackEventReceived += Raise.Event<InformationReceivedHandler>
        //        (this, new TrackInAirspaceEvent { tracks = tl1 });

        //    List<Track> tl2 = new List<Track>();
        //    tl2.Add(new Track
        //    {
        //        Altitude = 8000,
        //        Tag = "EZ666",
        //        Timer = Parse("20191205121108500"),
        //        XCoordinate = 20000,
        //        YCoordinate = 10000
        //    });
        //    tl2.Add(new Track
        //    {
        //        Altitude = 12000,
        //        Tag = "GG404",
        //        Timer = Parse("20191205121109600"),
        //        XCoordinate = 20000,
        //        YCoordinate = 10000
        //    });

        //    tr_interface.TrackEventReceived += Raise.Event<InformationReceivedHandler>
        //        (this, new TrackInAirspaceEvent { tracks = tl2 });

        //    Assert.That(tracks2[0], Is.EqualTo(tl2[0]));
        //}









        //[Test] // Adding a track

        //public void TestAddTracks()
        //{
        //    List<Track> t1 = AddTracks();
        //    tr_interface. += Raise.Event<TrackInAirspaceEvent>;

        //}



    }
}
