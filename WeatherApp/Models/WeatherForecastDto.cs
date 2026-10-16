namespace WeatherApp.Services;

public class WeatherForecastDto
{
    public List<DailyWeather> DailyWeathers { get; set; } = new ();
}

public record DailyWeather(string day, double minTemp, double maxTemp, string weatherDescription); 
