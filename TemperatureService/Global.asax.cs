using System;
using System.Web;

namespace TemperatureService
{
    public class Global : HttpApplication
    {
        private static SerialPortReader serialPortReader;

        protected void Application_Start(object sender, EventArgs e)
        {
            serialPortReader = new SerialPortReader();
        }

        public static SerialPortReader SerialPortReader
        {
            get { return serialPortReader; }
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}