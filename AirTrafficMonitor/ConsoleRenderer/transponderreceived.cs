using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirTrafficMonitor.ConsoleRendering
{


    public class PlaneEventsArgs : EventArgs
    {
        public Track Plane { get; set; }
    }
    public class TransponderReceiver
    {
        // Dette er delegaten som er defineret, det er metodens signature
        public delegate void DataReceivedEventHandler(object source, PlaneEventsArgs args);

        // Dette er eventen som bliver defineret ud fra delegaten. Eventen hedder DataReceived
        public event DataReceivedEventHandler DataReceived;

        public void Receive(Track plane)
        {
            Console.WriteLine("Vi har modtaget nyt flydata");
            Thread.Sleep(5000);

            OnDataReceived(plane);

        }
        protected virtual void OnDataReceived(Track plane)
        {
            //checker om der er nogle subscribed til dette event
            if (DataReceived != null)
                //this er hvilken klasse der publisher eventet. plane er hvad vil man sende med.
                DataReceived(this, new PlaneEventsArgs() { Plane = plane });
        }
    }
}