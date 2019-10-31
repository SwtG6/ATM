﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AirTrafficMonitor;
using Calculator.TransponderReceiver;
using Calculator.Data;
using TransponderReceiver;


namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TransponderReceiverFactory TransponderReceiverFactory = new TransponderReceiverFactory();

            ITransponderReceiver TransponderReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();

            IDataFormat dataFormat = new DataFormat();

            ITransponderReceiverClient TransponderReceiverClient =
                new TransponderReceiverClient(TransponderReceiver, dataFormat);



            // Using the real transponder data receiver
            var receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();

            // Dependency injection with the real TDR
            var system = new Calculator.TransponderReceiver.TransponderReceiverClient(receiver, dataFormat);

            // Let the real TDR execute in the background
            while (true)
                Thread.Sleep(1000);
        }
    }
}
