namespace WeatherApp.Services;

public interface IWeatherService
{
    Task<MeteoResponce?> GetForecastAsync(double latitude, double longitude);
}