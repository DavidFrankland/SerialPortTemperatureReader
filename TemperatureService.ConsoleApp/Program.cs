using System;
using System.Net.Http;
using System.Threading;
using Microsoft.Owin.Hosting;
using Newtonsoft.Json;
using TemperatureService.Domain;

namespace TemperatureService.ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            Console.Title = "Temperature Server";

            string baseAddress = "http://localhost:9000/";

            using (WebApp.Start<Startup>(baseAddress))
            {
                var client = new HttpClient();

                while (true)
                {
                    var requestUri = baseAddress + "api/temperature";
                    var response = client.GetAsync(requestUri).Result;
                    var json = response.Content.ReadAsStringAsync().Result;
                    var model = JsonConvert.DeserializeObject<TemperatureViewModel>(json);
                    var temperature = model.Temperature == null ? "unknown" : model.Temperature.ToString();

                    Console.Clear();
                    Console.WriteLine($"Base address: {baseAddress}");
                    Console.WriteLine($"Request URI: {requestUri}");
                    Console.WriteLine($"JSON: {json}");
                    Console.WriteLine($"Temperature: {temperature}");
                    Console.WriteLine($"Message: {model.Message}");
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
            }
        }
    }
}