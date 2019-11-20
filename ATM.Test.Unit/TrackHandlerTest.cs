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
using AirTrafficMonitor.TransponderReceiver;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;

namespace ATM.Test.Unit
{

    [TestFixture]
    class TrackHandlerTest
    {
        private List<Track> tracks1 = new List<Track>();
        private List<Track> tracks2 = new List<Track>();

        private List<Tracks> collisionTracks = new List<Tracks>();

        private TrackHandler uut;
        private ITransponderReceiver tr_interface;
        private IDataFormat df_interface;
        private IConditionLogger logger;

        [SetUp]
        public void Setup()
        {
            tr_interface = Substitute.For<ITransponderReceiver>();
            df_interface = Substitute.For<IDataFormat>();
            logger = new ConditionLogger();
            uut = new TrackHandler(df_interface,logger);
            uut.RaiseEvent += RaiseEventHandler;

        }

        public void RaiseEventHandler(object o, TrackUpdateEvent e)
        {
            tracks1 = e.ListOfNewTracks;
            tracks2 = e.ListOfUpdatedTracks;
            collisionTracks = e.ListOfCollidingTracks;

        }

        [Test] // Tag
        public void TagTest()
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


        [SetUp] // Adding a track

       // https://stackoverflow.com/questions/7068843/how-to-use-datetime-parse-to-create-a-datetime-object/7068890
        public DateTime Parse(string time)
        {
            return DateTime.ParseExact(time, "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
        }

        public List<Track> AddTracks()
        {
            List<Track> t1 = new List<Track>();
            t1.Add(new Track
            {
                Altitude = 10000,
                Tag = "ABC1337",
                Timer = Parse("20191205121106300"),
                XCoordinate = 6666,
                YCoordinate = 6969
            });
            t1.Add(new Track
            {
                Altitude = 12000,
                Tag = "DEF1234",
                Timer = Parse("20191205121107400"),
                XCoordinate = 20000,
                YCoordinate = 10000
            });

            return t1;
        }

        //[Test] // Adding a track

        //public void TestAddTracks()
        //{
        //    List<Track> t1 = AddTracks();
        //    tr_interface. += Raise.Event<TrackInAirspaceEvent>;

        //}



    }
}
