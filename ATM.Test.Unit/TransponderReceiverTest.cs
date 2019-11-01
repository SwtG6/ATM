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

namespace ATM.Test.Unit
{
    [TestFixture]
    public class TransponderReceiverTest
    {
        private ITransponderReceiver _fakeTransponderReceiver;
        private IDataFormat _fakeDataFormat;

        private TransponderReceiverClient _uut;


        [SetUp]
        public void Setup()
        {
            // Make a fake Transponder Data Receiver
            _fakeTransponderReceiver = Substitute.For<ITransponderReceiver>();
            _fakeDataFormat = Substitute.For<IDataFormat>();

            // Inject the fake TDR
            _uut = new TransponderReceiverClient(_fakeTransponderReceiver, _fakeDataFormat);

        }


        [TestCase("ATR423;39045;12932;14000;20151006213456789")]
        [TestCase("BCD123;10005;85890;12000;20151006213456789")]
        [TestCase("XYZ987;25059;75654;4000;20151006213456789")]
        public void ReceiverOnTransponderDataReady_CreateEvent_DataformatCreateTrackCalled(string input)
        {
            List<string> testData = new List<string>();
            testData.Add(input);

            //_fakeTransponderReceiver.TransponderDataReady
            //    += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            _fakeDataFormat.Received(1).CreateTrack(input);

        }
        //[Test]
        //public void TestReception()
        //{
        //    //// Setup test data
        //    //List<string> testData = new List<string>();
        //    //testData.Add("ATR423;39045;12932;14000;20151006213456789");
        //    //testData.Add("BCD123;10005;85890;12000;20151006213456789");
        //    //testData.Add("XYZ987;25059;75654;4000;20151006213456789");

        //    //// Act: Trigger the fake object to execute event invocation
        //    //_fakeTransponderReceiver.TransponderDataReady += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

        //    //// Assert something here or use an NSubstitute Received


        //}

    }
}
