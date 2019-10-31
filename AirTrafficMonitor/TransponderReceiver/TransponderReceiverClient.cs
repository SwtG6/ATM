using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.TransponderReceiver;


namespace Calculator.TransponderReceiver
{

    public class TransponderReceiver : ITransponderReceiver
    {
        private ITransponderReceiver DataReceiver;

        public event EventHandler<RawTransponderDataEventArgs> TransponderDataReady;

        public TransponderReceiver(ITransponderReceiver DataReceiver)
        {
            this.DataReceiver = DataReceiver;

            this.DataReceiver.TransponderDataReady += HandleTransponderData;

        }

        public void HandleTransponderData(object o, RawTransponderDataEventArgs arg)
        {


        }

    }

}
