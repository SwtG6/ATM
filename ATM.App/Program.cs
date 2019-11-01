using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AirTrafficMonitor;
using AirTrafficMonitor.TransponderReceiver;
using AirTrafficMonitor.Data;
using TransponderReceiver;


namespace ATMApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Using the real transponder data receiver
            var receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();

            // Dependency injection with the real TDR
            var system = new AirTrafficMonitor.TransponderReceiver.TransponderReceiverClient(receiver);

            // Let the real TDR execute in the background
            while (true)
                Thread.Sleep(1000);
        }
    }


    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        TransponderReceiverFactory TransponderReceiverFactory = new TransponderReceiverFactory();

    //        ITransponderReceiver TransponderReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();

    //        IDataFormat dataFormat = new DataFormat();

    //        ITransponderReceiverClient TransponderReceiverClient =
    //            new TransponderReceiverClient(TransponderReceiver, dataFormat);



    //        //    // Using the real transponder data receiver
    //        //    var receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();

    //        //    // Dependency injection with the real TDR
    //        //    var system = new AirTrafficMonitor.TransponderReceiver.TransponderReceiverClient(receiver, dataFormat);

    //        // Let the real TDR execute in the background
    //        while (true)
    //            Thread.Sleep(1000);
    //    }
    //}
}
