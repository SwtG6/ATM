using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;
using AirTrafficMonitor.Data;
using AirTrafficMonitor.TransponderReceiverClient;
using AirTrafficMonitor.TransponderReceiver;
//using TransponderDataEventArgs = TransponderReceiver.TransponderDataEventArgs;

namespace ATM.Test.Unit
{
    [TestFixture]
    class DataFormatTest
    {
        //private ITransponderReceiverClient _fakeTransponderReceiver { get; set; }
        //private TrackInAirspaceEvent _dataFormatEventArgs { get; set; }
        private IDataFormat UUT { get; set; }

        [SetUp]
        public void Setup()
        {
            //_fakeTransponderReceiver = Substitute.For<ITransponderReceiverClient>();
            
            UUT = new DataFormat();

            //new DateTime(2015, 10, 06, 21, 34, 56, 789);
        }

        [Test] // Test af at modtaget Track-data bliver formatteret korrekt.
        public void TrackDataFormattedTest()
        {
            // Setup test data
            var testTrackData = UUT.CreateTrack("ATR423;39045;12932;14000;20151006213456789");

            // Assert something here or use an NSubstitute Received
            Assert.That(testTrackData.Tag, Is.EqualTo("ATR423"));
            Assert.That(testTrackData.XCoordinate, Is.EqualTo(39045));
            Assert.That(testTrackData.YCoordinate, Is.EqualTo(12932));
            Assert.That(testTrackData.Altitude, Is.EqualTo(14000));
            Assert.That(testTrackData.Timer, Is.EqualTo(new DateTime(2015, 10, 06, 21, 34, 56, 789)));
        }

        //[Test] // Test af hvorvidt der modtages et Event når funktionen kaldes.
        //public void TransponderDataEventArgsTest()
        //{
        //    // Setup test data
        //    var testTrackList = new List<string>();
        //    testTrackList.Add("ATR423;39045;12932;14000;20151006213456789");

        //    UUT.TransponderDataReady += (sender, e) => { _dataFormatEventArgs = e; };

        //    // Trigger the fake object to execute event invocation
        //    _fakeTransponderReceiver.TransponderDataReady +=
        //        Raise.EventWith(new object(), new RawTransponderDataEventArgs(testTrackList));

        //    // Assert that an event was received
        //    Assert.NotNull(_dataFormatEventArgs);
        //}
    }
}
