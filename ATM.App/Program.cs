using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor;

namespace ATMApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Calc MyCalculator = new Calc();

            int a = 2;
            int b = 3;

            Console.WriteLine("add {0} + {1} = {2} ", a, b, MyCalculator.add(a, b));
        }
    }
}
