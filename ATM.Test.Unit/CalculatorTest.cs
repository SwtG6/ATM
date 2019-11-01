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
            Track testTrack = new Track();

            testTrack.XCoordinate = 2000;
            testTrack.YCoordinate = 45000;
            testTrack.Altitude = 15000;
            //result = false

            Assert.That(TrackIsInsideAirSpace(testTrack), Is.EqualTo(false));
        }

        //[Test]
        //public void TrackOutsideYCoordinateLowAirspaceTest()
        //{
        //    Track testTrack = new Track();

        //    testTrack.XCoordinate = 20000;
        //    testTrack.YCoordinate = 4500;
        //    testTrack.Altitude = 15000;
        //    //result = false

        //    Assert.That(TrackIsInsideAirSpace(testTrack), Is.EqualTo(false));
        //}

        //[Test]
        //public void TrackOutsideXAltitudeHighAirspaceTest()
        //{
        //    Track testTrack = new Track();

        //    testTrack.XCoordinate = 2000;
        //    testTrack.YCoordinate = 45000;
        //    testTrack.Altitude = 150000;
        //    //result = false

        //    Assert.That(TrackIsInsideAirSpace(testTrack), Is.EqualTo(false));
        //}
    }
}
