using System.Net.Http.Json;

namespace WeatherApp.Services;

public class WeatherService(HttpClient httpClient) : IWeatherService
{
    private readonly HttpClient _httpClient = httpClient;

    public Task<MeteoResponce?> GetForecastAsync(double latitude, double longitude)
    {
        try
        {
            return _httpClient.GetFromJsonAsync<MeteoResponce?>(new Uri($"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current_weather=true&&daily=weather_code,temperature_2m_max,temperature_2m_min&timezone=auto"));
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }
}