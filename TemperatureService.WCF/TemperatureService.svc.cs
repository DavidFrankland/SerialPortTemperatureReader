namespace TemperatureService.WCF
{
    public class TemperatureService : ITemperatureService
    {
        public decimal? GetTemperature()
        {
            return Global.SerialPortReader.TemperatureViewModel.Temperature;
        }
    }
}
