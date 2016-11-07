using System.Web.Http;
using log4net;
using log4net.Config;
using Owin;
using TemperatureService.Domain;

namespace TemperatureService.ConsoleApp
{
    public class Startup
    {
        private ILog logger;

        public static SerialPortReader SerialPortReader { get; private set; }

        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            XmlConfigurator.Configure();
            logger = LogManager.GetLogger("TemperatureService");
            SerialPortReader = new SerialPortReader(logger);

            // Configure Web API for self-host. 
            var config = new HttpConfiguration();

            config.EnableCors();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            appBuilder.UseWebApi(config);
        }
    }
}