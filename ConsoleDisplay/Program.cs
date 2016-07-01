using System;
using System.Threading;
using ConsoleDisplay.TemperatureService;

namespace ConsoleDisplay
{
    class Program
    {
        static void Main()
        {
            ITemperatureService temperatureService = new TemperatureServiceClient();

            while (true)
            {
                Console.WriteLine(temperatureService.GetTemperature());
                Thread.Sleep(1000);
            }
        }
    }
}
