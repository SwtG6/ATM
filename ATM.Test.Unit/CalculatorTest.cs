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
        [Test] // Test 1: Flyet er indenfor det definerede airspace.
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

        [Test] //Test 2: Flyets koordinator måler for lavt på X-aksen, og er derfor ikke inde i vores airspace.
        public void TrackOutsideXCoordinateLowAirspaceTest()
        {
            Track testTrackXL = new Track();

            testTrackXL.XCoordinate = 2000;
            testTrackXL.YCoordinate = 45000;
            testTrackXL.Altitude = 15000;
            //result = false

            Assert.That(TrackIsInsideAirSpace(testTrackXL), Is.EqualTo(false));
        }

        [Test] //Test 3: Flyets koordinator måler for lavt på Y-aksen, og er derfor ikke inde i vores airspace.
        public void TrackOutsideYCoordinateLowAirspaceTest()
        {
            Track testTrackYL = new Track();

            testTrackYL.XCoordinate = 20000;
            testTrackYL.YCoordinate = 4500;
            testTrackYL.Altitude = 15000;
            //result = false

            Assert.That(TrackIsInsideAirSpace(testTrackYL), Is.EqualTo(false));
        }

        [Test] //Test 4: Flyets koordinator måler for højt på altitude, og er derfor ikke inde i vores airspace.
        public void TrackOutsideAltitudeHighAirspaceTest()
        {
            Track testTrackAH = new Track();

            testTrackAH.XCoordinate = 2000;
            testTrackAH.YCoordinate = 45000;
            testTrackAH.Altitude = 150000;
            //result = false

            Assert.That(TrackIsInsideAirSpace(testTrackAH), Is.EqualTo(false));
        }

        [Test] // Test 5: Testen om vores GetDistance-funktion virker efter hensigten.
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

        [Test] // Test 6: Tester om 2 fly er ved at kollidere, baseret på vores GetDistance-funktion.
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

        [Test] // Test 7: Udregning af altitude afstanden mellem to placeringer.
        public void AltitudeDistanceTest()
        {
            Track testAltTrack1 = new Track();
            testAltTrack1.Altitude = 10000;

            Track testAltTrack2 = new Track();
            testAltTrack2.Altitude = 15000;

            Assert.That(GetAltitudeDistance(testAltTrack1.Altitude, testAltTrack2.Altitude), Is.EqualTo(5000));
        }

        [Test] // Test 8: Udregning af forskellen i kurs mellem to placeringer.
        public void CurrentCourseTest()
        {
            Track testCourseTrack1 = new Track();
            testCourseTrack1.XCoordinate = 20000;
            testCourseTrack1.YCoordinate = 40000;

            Track testCourseTrack2 = new Track();
            testCourseTrack2.XCoordinate = 30000;
            testCourseTrack2.YCoordinate = 50000;

            Assert.That(GetCurrentCourse(testCourseTrack1, testCourseTrack2), Is.EqualTo(45));
        }


        //[Test]
        //public void TrackVelocityTest()
        //{
        //    Track testVelTrack1 = new Track();
        //    //DateTime testVelTime1 = new DateTime(2015,10,06,21,34,56,789);

        //    testVelTrack1.Timer = DateTime.Today;

        //    Track testVelTrack2 = new Track();
        //    testVelTrack1.Timer 

        //    Assert.That(GetCurrentVelocity(testVelTrack1, testVelTrack2), Is.EqualTo(4));
        //}
    }
}
