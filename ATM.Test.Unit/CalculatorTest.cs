using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Track;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
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

        [Test]

        public void DistanceBetweenTracksTest()
        {
            Track testTrackDist1 = new Track();
            testTrackDist1.XCoordinate = 20000;
            testTrackDist1.YCoordinate = 50000;
            testTrackDist1.Altitude = 10000;

            Track testTrackDist2 = new Track();
            testTrackDist2.XCoordinate = 50000;
            testTrackDist2.YCoordinate = 50000;
            testTrackDist2.Altitude = 10000;

            Assert.That(GetDistance(testTrackDist1, testTrackDist2), Is.EqualTo(30000));
        }



        [Test]
        public void TracksCollidingTest()
        {
            Track testTrack1 = new Track();
            testTrack1.XCoordinate = 42000;
            testTrack1.YCoordinate = 45000;
            testTrack1.Altitude = 10000;

            Track testTrack2 = new Track();
            testTrack2.XCoordinate = 45000;
            testTrack2.YCoordinate = 45000;
            testTrack2.Altitude = 9900;

            Assert.That(AreTracksColliding(testTrack1, testTrack2), Is.EqualTo(true));
        }
    }
}
