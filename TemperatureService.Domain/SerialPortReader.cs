using System;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using log4net;

namespace TemperatureService.Domain
{
    public class SerialPortReader
    {
        private SerialPort serialPort;
        private readonly ILog logger;

        public TemperatureViewModel TemperatureViewModel { get; private set; }

        private const int BAUD_RATE = 9600;

        public SerialPortReader(ILog logger)
        {
            this.logger = logger;

            new Task(DoWork).Start();
        }

        private void FindSerialPort()
        {
            TemperatureViewModel = new TemperatureViewModel();

            while (true)
            {
                for (int portNumber = 1; portNumber <= 8; portNumber++)
                {
                    try
                    {
                        TemperatureViewModel.Message = "Finding temperature sensor";
                        string portName = $"COM{portNumber}";
                        logger.Debug($"Attempting to open {portName}");
                        var testPort = new SerialPort(portName, BAUD_RATE);
                        testPort.ReadTimeout = 1000;
                        testPort.Open();
                        logger.Debug("Port open, checking temperature sensor");
                        var line = testPort.ReadLine();
                        decimal temperature;
                        if (decimal.TryParse(line, out temperature))
                        {
                            logger.Debug("Temperature sensor found");
                            serialPort = testPort;
                            return;
                        }
                        logger.Debug("Temperature sensor not found");
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Error", ex);
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                    }
                }
            }
        }

        private void DoWork()
        {
            while (true)
            {
                try
                {
                    FindSerialPort();
                    while (true)
                    {
                        var line = serialPort.ReadLine();
                        decimal temperature;
                        TemperatureViewModel.Temperature = decimal.TryParse(line, out temperature) ? (decimal?)temperature : null;
                        TemperatureViewModel.Message = $"{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}";
                    }
                }
                catch (Exception ex)
                {
                    TemperatureViewModel.Temperature = null;
                    TemperatureViewModel.Message = ex.Message;
                    logger.Error("Error", ex);
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
            }
        }
    }
}
