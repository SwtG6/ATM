using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Track;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TransponderReceiver;
using Calculator = AirTrafficMonitor.Calculator.Calculator;
using static AirTrafficMonitor.Calculator.Calculator;

namespace ATM.Test.Unit
{
    [TestFixture]
    class CalculatorTest
    {
        [Test]
        public void TrackInsideAirspaceTest()
        {
            //List<Track> testTrack = new List<Track>();

            Track testTrack = new Track();

            testTrack.XCoordinate = 20000;
            testTrack.YCoordinate = 45000;
            testTrack.Altitude = 15000;
            //result = true

            Assert.That(TrackIsInsideAirSpace(testTrack), Is.EqualTo(true));
        }

        [Test]
        public void TrackOutsideXCoordinateLowAirspaceTest()
        {
            Track testTrackXL = new Track();

            testTrackXL.XCoordinate = 2000;
            testTrackXL.YCoordinate = 45000;
            testTrackXL.Altitude = 15000;
            //result = false

            Assert.That(TrackIsInsideAirSpace(testTrackXL), Is.EqualTo(false));
        }

        [Test]
        public void TrackOutsideYCoordinateLowAirspaceTest()
        {
            Track testTrackYL = new Track();

            testTrackYL.XCoordinate = 20000;
            testTrackYL.YCoordinate = 4500;
            testTrackYL.Altitude = 15000;
            //result = false

            Assert.That(TrackIsInsideAirSpace(testTrackYL), Is.EqualTo(false));
        }

        [Test]
        public void TrackOutsideAltitudeHighAirspaceTest()
        {
            Track testTrackAH = new Track();

            testTrackAH.XCoordinate = 2000;
            testTrackAH.YCoordinate = 45000;
            testTrackAH.Altitude = 150000;
            //result = false

            Assert.That(TrackIsInsideAirSpace(testTrackAH), Is.EqualTo(false));
        }


    }
}
