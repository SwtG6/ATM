using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Data;
using Calculator.TransponderReceiver;


namespace Calculator.TransponderReceiver
{

    public class TransponderReceiver : ITransponderReceiver
    {
        // private ITransponderReceiver dataReceiver;
        private IDataFormat _dataFormatter;

        public event EventHandler<RawTransponderDataEventArgs> TransponderDataReady;

        public TransponderReceiver(ITransponderReceiver dataReceiver, IDataFormat dataFormatter)
        {
            // this.dataReceiver = dataReceiver;
            _dataFormatter = dataFormatter;

            //this.dataReceiver.TransponderDataReady += HandleTransponderData;
            TransponderDataReady += HandleTransponderData;
        }

        public void HandleTransponderData(object o, RawTransponderDataEventArgs arg)
        {
            var list = arg.TransponderData.Select(track => _dataFormatter.CreateTrack(track)).ToList();

            foreach (var transponderData in arg.TransponderData)
            {
                list.Add(_dataFormatter.CreateTrack(transponderData));

                // handler?.Invoke(this, new RawTransponderDataEventArgs(list));
            }

            if (TransponderDataReady != null)
            {
                TransponderDataReady(this, new RawTransponderDataEventArgs(list));
            }
            

        }

    }

}
