using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AirTrafficMonitor.ConsoleRendering
{

    class Program
    {
        static void Main(string[] args)
        {
            var plane = new Track() { Tag = "Plane 1", Position = "x=1000m y =2000m", Altitude = "5000m", Velocity = "200 m/s", Course = "0 degrees" };
            var transponderReceiver = new TransponderReceiver(); //publisher
            var consoleWrite = new ConsoleWrite(); // subscriber

            //Sådan subscriber jeg.Så transponderReceiver metoden vil publishe eventet Datareceived til consoleWrite
            //så consoleWrite ved hvornår den skal skrive til console. OnDataReceived er så det sted i metoden hvor jeg er færdig og gerne vil have at mit event skal ske

            transponderReceiver.DataReceived += consoleWrite.OnDataReceived;

       

            transponderReceiver.Receive(plane);
        }
    }

}