using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;
using AirTrafficMonitor.Data;
using TransponderDataEventArgs = TransponderReceiver.TransponderDataEventArgs;

namespace ATM.Test.Unit
{
    [TestFixture]
    class DataFormatTest
    {
        private ITransponderReceiver _fakeTransponderReceiver { get; set; }
        //private TransponderDataEventArgs dataFormatEventArgs { get; set; }
        private IDataFormat UUT { get; set; }

        [SetUp]
        public void setup()
        {
            _fakeTransponderReceiver = Substitute.For<ITransponderReceiver>();

            UUT = new DataFormat(_fakeTransponderReceiver);
        }

        [Test]
        public void FlightDataFormattedTest()
        {
            var testTrackData = UUT.CreateTrack("ATR423;39045;12932;14000;20151006213456789");

            Assert.That(testTrackData.Tag, Is.EqualTo("ATR423"));
            Assert.That(testTrackData.XCoordinate, Is.EqualTo(39045));
            Assert.That(testTrackData.YCoordinate, Is.EqualTo(12932));
            Assert.That(testTrackData.Altitude, Is.EqualTo(14000));
            //Assert.That(testTrackData.Timer, Is.EqualTo());
        }
    }

}




//    [TestFixture]
//    class DataFormatTest
//    {
//        //DataFormat uut;

//        //private IDataFormat _fakeDataFormat;
//        //private DataFormat  _uut;

//        private ITransponderReceiver _fakeTransponderReceiver;
//        //private IDataFormat _fakeDataFormat;


//        [SetUp]
//        public void setup()
//        {
//            _fakeTransponderReceiver = Substitute.For<ITransponderReceiver>();

//            _uut = new TransponderReceiverClient(_fakeTransponderReceiver);

//            //_fakeDataFormat = Substitute.For<IDataFormat>();

//            //_uut = new DataFormat(_fakeDataFormat);

//        }

//        // Setup test data

//        [TestCase("ATR423;39045;12932;14000;20151006213456789")]
//        public void TrackTagDataFormatTest(string testString)
//        {

//            Track track = _uut.CreateTrack(testString);

//            Assert.That(track.Tag, Is.EqualTo("ATR423"));

//        }


//        //[Test]
//        //public void TestReception()
//        //{
//        //List<string> testData = new List<string>();
//        //testData.Add("ATR423;39045;12932;14000;20151006213456789");

//        //_fakeDataFormat.TransponderDataReady
//        //    += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

//    }
//}

