using System;
using System.ServiceModel;

namespace TemperatureService
{
    [ServiceContract]
    public interface ITemperatureService
    {
        [OperationContract]
        decimal? GetTemperature();
    }
}
