using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    public delegate string MuubsDel(string str);

    class EventCondition1
    {
        event MuubsDel FlobsEvent;

        public EventCondition1()
        {
            this.FlobsEvent += new MuubsDel(this.Airspace);
        }
        public string Airspace(string currentairspace)
        {
            return "SWT airspace " + currentairspace;
        }
        static void Main(string[] args)
        {
            EventCondition1 obj1;
            obj1 = new EventCondition1();
            string airspace1 = obj1.FlobsEvent("Første iteration af events til console rendering");
            Console.WriteLine(airspace1);
            //Console.ReadKey();
            Thread.Sleep(5000);

            EventCondition1 obj2;
            obj2 = new EventCondition1();
            string airspace2 = obj2.FlobsEvent("Vi er nu i nyt airspace");
            Console.WriteLine(airspace2);
            Console.ReadKey();
        }

    }
}

