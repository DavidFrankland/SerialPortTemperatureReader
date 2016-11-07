using System;
using System.Web;
using log4net;
using log4net.Config;
using TemperatureService.Domain;

namespace TemperatureService.WCF
{
    public class Global : HttpApplication
    {
        private static SerialPortReader serialPortReader;
        private static ILog logger;

        public static SerialPortReader SerialPortReader => serialPortReader;

        protected void Application_Start(object sender, EventArgs e)
        {
            XmlConfigurator.Configure();
            logger = LogManager.GetLogger("TemperatureService");
            logger.Debug("Application_Start");
            serialPortReader = new SerialPortReader(logger);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //logger.Debug("Session_Start");
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //logger.Debug("Application_BeginRequest");
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            //logger.Debug("Application_AuthenticateRequest");
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            logger.Debug("Application_Error");
        }

        protected void Session_End(object sender, EventArgs e)
        {
            //logger.Debug("Session_End");
        }

        protected void Application_End(object sender, EventArgs e)
        {
            logger.Debug("Application_End");
        }
    }
}