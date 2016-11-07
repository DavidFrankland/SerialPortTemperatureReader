using System.ServiceModel;

namespace TemperatureService.WCF
{
    [ServiceContract]
    public interface ITemperatureService
    {
        [OperationContract]
        decimal? GetTemperature();
    }
}
