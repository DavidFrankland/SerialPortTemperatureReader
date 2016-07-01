using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TemperatureService
{
    public class TemperatureService : ITemperatureService
    {
        public decimal? GetTemperature()
        {
            return Global.SerialPortReader.Temperature;
        }
    }
}
