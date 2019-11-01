using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Data;
using AirTrafficMonitor.TransponderReceiver;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;
using AirTrafficMonitor.Track;


namespace ATM.Test.Unit
{
    public class TestTransponderReceiverClient
    {
        private ITransponderReceiver _fakeTransponderReceiver;
        private TransponderReceiverClient _uut;

        [SetUp]
        public void Setup()
        {
            // Make a fake Transponder Data Receiver
            _fakeTransponderReceiver = Substitute.For<ITransponderReceiver>();
            // Inject the fake TDR
           // _uut = new TransponderReceiverClient(_fakeTransponderReceiver);
        }

        [Test]
        public void TestReception()
        {
            // Setup test data
            List<string> testData = new List<string>();
            testData.Add("ATR423;39045;12932;14000;20151006213456789");
            testData.Add("BCD123;10005;85890;12000;20151006213456789");
            testData.Add("XYZ987;25059;75654;4000;20151006213456789");

            // Act: Trigger the fake object to execute event invocation
            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            // Assert something here or use an NSubstitute Received
        }
    }
}






//[TestFixture]
    //public class TransponderReceiverTest
    //{






    //private ITransponderReceiver _fakeTransponderReceiver;
    //private IDataFormat _fakeDataFormat;

    //private TransponderReceiverClient _uut;

    //private int _numberOfEvents;

    //[SetUp]
    //public void Setup()
    //{
    //    _fakeTransponderReceiver = Substitute.For<ITransponderReceiver>();
    //    //    _fakeDataFormat = Substitute.For<IDataFormat>();

    //    _uut = new DataFormat(_fakeTransponderReceiver);


    //}


    //[Test]
    //public void DataFormatTest()
    //{
    //    // Setup test data

    //    var testTrack = _uut.CreateTrack("ATR423;39045;12932;14000;20151006213456789");

    //}



















    //    _numberOfEvents = 0;


    //    // Make a fake Transponder Data Receiver
    //    _fakeTransponderReceiver = Substitute.For<ITransponderReceiver>();
    //    _fakeDataFormat = Substitute.For<IDataFormat>();

    //    // Inject the fake TDR
    //    _uut = new TransponderReceiverClient(_fakeTransponderReceiver, _fakeDataFormat);


    //    _uut.TransponderDataReady += (sender, args) => _numberOfEvents++;
    //}


    //[TestCase("ATR423;39045;12932;14000;20151006213456789")]
    ////[TestCase("BCD123;10005;85890;12000;20151006213456789")]
    ////[TestCase("XYZ987;25059;75654;4000;20151006213456789")]
    //public void ReceiverOnTransponderDataReady_CreateEvent_DataFormatCreateTrackCalled(string input)
    //{
    //    List<string> testData = new List<string>();
    //    testData.Add(input);

    //    _fakeTransponderReceiver.TransponderDataReady
    //        += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

    //    //_fakeDataFormat.Received(1).CreateTrack(input);



    //    Assert.AreEqual(1, _numberOfEvents);
    //}










    //    List<string> testData = new List<string>();
    //    testData.Add("ATR423;39045;12932;14000;20151006213456789");
    //    testData.Add("BCD123;10005;85890;12000;20151006213456789");
    //    testData.Add("XYZ987;25059;75654;4000;20151006213456789");

    //    // Act: Trigger the fake object to execute event invocation
    //    _fakeTransponderReceiver.TransponderDataReady += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

    // Assert something here or use an NSubstitute Received






    //_fakeDataFormat.Received(1).CreateTrack(testData);



