using System;
using System.IO.Ports;
using System.Threading.Tasks;

namespace TemperatureService
{
    public class SerialPortReader
    {
        private readonly SerialPort serialPort;
        public decimal? Temperature { get; private set; }

        private const int BAUD_RATE = 9600;

        public SerialPortReader()
        {
            for (int i = 1; i <= 8; i++)
            {
                try
                {
                    string portName = string.Format("COM{0}", i);
                    SerialPort testPort = new SerialPort(portName, BAUD_RATE);
                    testPort.ReadTimeout = 1000;
                    testPort.Open();
                    var line = testPort.ReadLine();
                    decimal temperature;
                    if (decimal.TryParse(line, out temperature))
                    {
                        serialPort = testPort;
                        new Task(DoWork).Start();
                        return;
                    }
                }
                catch { }
            }
        }

        private void DoWork()
        {
            while (true)
            {
                try
                {
                    if (!serialPort.IsOpen)
                    {
                        serialPort.Open();
                    }

                    var line = serialPort.ReadLine();
                    decimal temperature;
                    Temperature = decimal.TryParse(line, out temperature) ? (decimal?)temperature : null;
                }
                catch
                {
                    Temperature = null;
                }
            }
        }
    }
}
