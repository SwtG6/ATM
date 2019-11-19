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
        #region Inside Airspace BVA Tests 

        [Test] // Test 1: Flyet er indenfor det definerede airspace. x(nom)
        public void TrackInsideAirspaceTestNom()
        {
            //List<Track> testTrack = new List<Track>();

            Track testTrack = new Track();

            testTrack.XCoordinate = 30000;
            testTrack.YCoordinate = 45000;
            testTrack.Altitude = 10000;
            //result = true

            Assert.That(TrackIsInsideAirSpace(testTrack), Is.EqualTo(true));
        }

        [Test] // Test 2: Flyet er indenfor det definerede airspace. x(min+) på X- og Y-akse.
        public void TrackInsideAirspaceTestXYMinPlus()
        {
            //List<Track> testTrack = new List<Track>();

            Track testTrack = new Track();

            testTrack.XCoordinate = 11000;
            testTrack.YCoordinate = 11000;
            testTrack.Altitude = 10000;
            //result = true

            Assert.That(TrackIsInsideAirSpace(testTrack), Is.EqualTo(true));
        }

        [Test] // Test 3: Flyet er indenfor det definerede airspace. x(min) på X- og Y-akse.
        public void TrackInsideAirspaceTestXYMin()
        {
            //List<Track> testTrack = new List<Track>();

            Track testTrack = new Track();

            testTrack.XCoordinate = 10000;
            testTrack.YCoordinate = 10000;
            testTrack.Altitude = 10000;
            //result = true

            Assert.That(TrackIsInsideAirSpace(testTrack), Is.EqualTo(true));
        }

        [Test] // Test 4: Flyet er indenfor det definerede airspace. x(max-) på X- og Y-akse.
        public void TrackInsideAirspaceTestXYMaxMinus()
        {
            //List<Track> testTrack = new List<Track>();

            Track testTrack = new Track();

            testTrack.XCoordinate = 89000;
            testTrack.YCoordinate = 89000;
            testTrack.Altitude = 10000;
            //result = true

            Assert.That(TrackIsInsideAirSpace(testTrack), Is.EqualTo(true));
        }

        [Test] // Test 5: Flyet er indenfor det definerede airspace. x(max) på X- og Y-akse.
        public void TrackInsideAirspaceTestXYMax()
        {
            //List<Track> testTrack = new List<Track>();

            Track testTrack = new Track();

            testTrack.XCoordinate = 90000;
            testTrack.YCoordinate = 90000;
            testTrack.Altitude = 10000;
            //result = true

            Assert.That(TrackIsInsideAirSpace(testTrack), Is.EqualTo(true));
        }

        #endregion Inside Airspace BVA Tests

        #region Outside Airspace Tests

        [Test] //Test 6: Flyets koordinator måler for lavt på X-aksen, og er derfor ikke inde i vores airspace.
        public void TrackOutsideXCoordinateLowAirspaceTest()
        {
            Track testTrackXL = new Track();

            testTrackXL.XCoordinate = 9000;
            testTrackXL.YCoordinate = 45000;
            testTrackXL.Altitude = 15000;
            //result = false

            Assert.That(TrackIsInsideAirSpace(testTrackXL), Is.EqualTo(false));
        }

        [Test] //Test 7: Flyets koordinator måler for lavt på Y-aksen, og er derfor ikke inde i vores airspace.
        public void TrackOutsideYCoordinateLowAirspaceTest()
        {
            Track testTrackYL = new Track();

            testTrackYL.XCoordinate = 20000;
            testTrackYL.YCoordinate = 9000;
            testTrackYL.Altitude = 15000;
            //result = false

            Assert.That(TrackIsInsideAirSpace(testTrackYL), Is.EqualTo(false));
        }

        [Test] //Test 8: Flyets koordinator måler for lavt på X- og Y-aksen, og er derfor ikke inde i vores airspace.
        public void TrackOutsideXYCoordinateLowAirspaceTest()
        {
            Track testTrackYL = new Track();

            testTrackYL.XCoordinate = 9900;
            testTrackYL.YCoordinate = 9900;
            testTrackYL.Altitude = 15000;
            //result = false

            Assert.That(TrackIsInsideAirSpace(testTrackYL), Is.EqualTo(false));
        }

        [Test] //Test 9: Flyets koordinator måler for højtt på X-aksen, og er derfor ikke inde i vores airspace.
        public void TrackOutsideXCoordinateHighAirspaceTest()
        {
            Track testTrackXL = new Track();

            testTrackXL.XCoordinate = 91000;
            testTrackXL.YCoordinate = 45000;
            testTrackXL.Altitude = 15000;
            //result = false

            Assert.That(TrackIsInsideAirSpace(testTrackXL), Is.EqualTo(false));
        }

        [Test] //Test 10: Flyets koordinator måler for højt på Y-aksen, og er derfor ikke inde i vores airspace.
        public void TrackOutsideYCoordinateHighAirspaceTest()
        {
            Track testTrackYL = new Track();

            testTrackYL.XCoordinate = 20000;
            testTrackYL.YCoordinate = 91000;
            testTrackYL.Altitude = 15000;
            //result = false

            Assert.That(TrackIsInsideAirSpace(testTrackYL), Is.EqualTo(false));
        }

        [Test] //Test 11: Flyets koordinator måler for højt på X- og Y-aksen, og er derfor ikke inde i vores airspace.
        public void TrackOutsideXYCoordinateHighAirspaceTest()
        {
            Track testTrackYL = new Track();

            testTrackYL.XCoordinate = 90500;
            testTrackYL.YCoordinate = 90500;
            testTrackYL.Altitude = 15000;
            //result = false

            Assert.That(TrackIsInsideAirSpace(testTrackYL), Is.EqualTo(false));
        }


        [Test] //Test 12: Flyets koordinator måler for højt på altitude, og er derfor ikke inde i vores airspace.
        public void TrackOutsideAltitudeHighAirspaceTest()
        {
            Track testTrackAH = new Track();

            testTrackAH.XCoordinate = 20000;
            testTrackAH.YCoordinate = 45000;
            testTrackAH.Altitude = 21000;
            //result = false

            Assert.That(TrackIsInsideAirSpace(testTrackAH), Is.EqualTo(false));
        }

        [Test] //Test 13: Flyets koordinator måler for lavt på altitude, og er derfor ikke inde i vores airspace.
        public void TrackOutsideAltitudeLoWAirspaceTest()
        {
            Track testTrackAH = new Track();

            testTrackAH.XCoordinate = 20000;
            testTrackAH.YCoordinate = 45000;
            testTrackAH.Altitude = 400;
            //result = false

            Assert.That(TrackIsInsideAirSpace(testTrackAH), Is.EqualTo(false));
        }

        #endregion Outside Airspace Tests

        #region GetDistance Test

        [Test] // Test 14: Test om GetDistance-funktionen virker efter hensigten ved forskel i X-koordinat
        public void DistanceBetweenTracksXTest()
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

        [Test] // Test 15: Test om GetDistance-funktionen virker efter hensigten ved forskel i Y-koordinat
        public void DistanceBetweenTracksYTest()
        {
            Track testTrackDist1 = new Track();
            testTrackDist1.XCoordinate = 50000;
            testTrackDist1.YCoordinate = 50000;
            testTrackDist1.Altitude = 10000;

            Track testTrackDist2 = new Track();
            testTrackDist2.XCoordinate = 50000;
            testTrackDist2.YCoordinate = 50500;
            testTrackDist2.Altitude = 10000;

            Assert.That(GetDistance(testTrackDist1, testTrackDist2), Is.EqualTo(500));
        }

        //[Test] // Test 15: Test om GetDistance-funktionen virker efter hensigten ved forskel i både X- og Y-koordinat
        //public void DistanceBetweenTracksXYTest()
        //{
        //    Track testTrackDist1 = new Track();
        //    testTrackDist1.XCoordinate = 45000;
        //    testTrackDist1.YCoordinate = 55000;
        //    testTrackDist1.Altitude = 10000;

        //    Track testTrackDist2 = new Track();
        //    testTrackDist2.XCoordinate = 55000;
        //    testTrackDist2.YCoordinate = 45000;
        //    testTrackDist2.Altitude = 10000;

        //    Assert.That(GetDistance(testTrackDist1, testTrackDist2), Is.EqualTo(14140));
        //}

        [Test] // Test 16: Test om GetDistance-funktionen virker efter hensigten ved ingen forskel i koordinator
        public void DistanceBetweenTracksTest()
        {
            Track testTrackDist1 = new Track();
            testTrackDist1.XCoordinate = 50000;
            testTrackDist1.YCoordinate = 50000;
            testTrackDist1.Altitude = 10000;

            Track testTrackDist2 = new Track();
            testTrackDist2.XCoordinate = 50000;
            testTrackDist2.YCoordinate = 50000;
            testTrackDist2.Altitude = 10000;

            Assert.That(GetDistance(testTrackDist1, testTrackDist2), Is.EqualTo(0));
        }


        #endregion GetDistance Test

        [Test] // Test 17: Udregning af altitude afstanden mellem to placeringer.
        public void AltitudeDistanceTest()
        {
            Track testAltTrack1 = new Track();
            testAltTrack1.Altitude = 10000;

            Track testAltTrack2 = new Track();
            testAltTrack2.Altitude = 15000;

            Assert.That(GetAltitudeDistance(testAltTrack1.Altitude, testAltTrack2.Altitude), Is.EqualTo(5000));
        }

        [Test] // Test 18: Udregning af forskellen i kurs mellem to tracks med forskellige X- og Y-koordinator.
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

        #region Collision Test

        [Test] // Test 19: Tester om 2 fly er ved at kollidere, baseret på vores GetDistance- og GetAltitudeDistance-funktioner. Hvor altitude forskellen gør at de ikke bør kollidere.
        public void TracksCollidingTestOnlyXY()
        {
            Track testTrack1 = new Track();
            testTrack1.XCoordinate = 42000;
            testTrack1.YCoordinate = 45000;
            testTrack1.Altitude = 10000;

            Track testTrack2 = new Track();
            testTrack2.XCoordinate = 45000;
            testTrack2.YCoordinate = 45000;
            testTrack2.Altitude = 9000;

            Assert.That(AreTracksColliding(testTrack1, testTrack2), Is.EqualTo(false));
        }

        [Test] // Test 20: Tester om 2 fly er ved at kollidere, baseret på vores GetDistance- og GetAltitudeDistance-funktioner. Hvor X/Y-forskellen gør at de ikke bør kollidere.
        public void TracksCollidingTestOnly()
        {
            Track testTrack1 = new Track();
            testTrack1.XCoordinate = 40000;
            testTrack1.YCoordinate = 45000;
            testTrack1.Altitude = 10000;

            Track testTrack2 = new Track();
            testTrack2.XCoordinate = 45000;
            testTrack2.YCoordinate = 45000;
            testTrack2.Altitude = 9900;

            Assert.That(AreTracksColliding(testTrack1, testTrack2), Is.EqualTo(false));
        }

        [Test] // Test 21: Tester om 2 fly er ved at kollidere, baseret på vores GetDistance- og GetAltitudeDistance-funktioner.
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

        #endregion Collision Test




        [Test]
        public void TrackVelocityTest()
        {

            DateTime testVelTime1 = new DateTime(2015,10,06,21,34,56,789);
            DateTime testVelTime2 = new DateTime(2015, 10, 06, 21, 34, 60, 789);

            //testVelTrack1.Timer = DateTime.Today;

            Track testVelTrack1 = new Track();
            testVelTrack1.Timer = testVelTime1;


            Track testVelTrack2 = new Track();
            testVelTrack1.Timer = testVelTime2;

            Assert.That(GetCurrentVelocity(testVelTrack1, testVelTrack2), Is.EqualTo(4));
        }
    }
}
