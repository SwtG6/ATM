using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.ConsoleRendering;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;
using AirTrafficMonitor.Data;
using AirTrafficMonitor.Track;
using AirTrafficMonitor.TransponderReceiver;
using AirTrafficMonitor.TrackHandler;
using Track = AirTrafficMonitor.Track.Track;

namespace ATM.Test.Unit
{
    [TestFixture]
    class DataFormatTest
    {
        //DataFormat uut;

        //private IDataFormat _fakeDataFormat;
        private DataFormat  _uut;


        [SetUp]
        public void setup()
        {
            _uut = new DataFormat();

            //_fakeDataFormat = Substitute.For<IDataFormat>();

            //_uut = new DataFormat(_fakeDataFormat);

        }

        // Setup test data

        [TestCase("ATR423;39045;12932;14000;20151006213456789")]
        public void TrackTagDataFormatTest(string testString)
        {

            Track track = _uut.CreateTrack(testString);

            Assert.That(track.Tag, Is.EqualTo("ATR423"));

        }


        //[Test]
        //public void TestReception()
        //{
        //List<string> testData = new List<string>();
        //testData.Add("ATR423;39045;12932;14000;20151006213456789");

        //_fakeDataFormat.TransponderDataReady
        //    += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

    }
}

