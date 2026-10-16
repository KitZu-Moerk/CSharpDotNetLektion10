using System.Text.Json.Serialization;

namespace WeatherApp.Services;

public class MeteoResponce
{
    [JsonPropertyName("latitude")] public double Latitude { get; set; }
    [JsonPropertyName("longitude")] public double Longitude { get; set; }
    [JsonPropertyName("generationtime_ms")] public double GenerationTimeMs { get; set; }
    [JsonPropertyName("utc_offset_seconds")] public int UtcOffsetSeconds { get; set; }
    [JsonPropertyName("timezone")] public string Timezone { get; set; }
    [JsonPropertyName("timezone_abbreviation")] public string TimezoneAbbreviation { get; set; }
    //[JsonPropertyName("elevation")] public int Elevation { get; set; }
    [JsonPropertyName("current_units")] public CurrentUnits CurrentUnits { get; set; }
    [JsonPropertyName("current")] public Current Current { get; set; }
    [JsonPropertyName("daily_units")] public DailyUnits DailyUnits { get; set; }
    [JsonPropertyName("daily")] public Daily Daily { get; set; }
}

public class CurrentUnits
{
    [JsonPropertyName("time")] public string Time { get; set; }
    [JsonPropertyName("interval")] public string Interval { get; set; }
    [JsonPropertyName("temperature_2m")] public string Temperature2m { get; set; }
    [JsonPropertyName("relative_humidity_2m")] public string RelativeHumidity2m { get; set; }
    [JsonPropertyName("weather_code")] public string WeatherCode { get; set; }
    [JsonPropertyName("wind_speed_10m")] public string WindSpeed10m { get; set; }
}

public class Current
{
    [JsonPropertyName("time")] public string Time { get; set; }
    [JsonPropertyName("interval")] public int Interval { get; set; }
    [JsonPropertyName("temperature_2m")] public double Temperature2m { get; set; }
    [JsonPropertyName("relative_humidity_2m")] public int RelativeHumidity2m { get; set; }
    [JsonPropertyName("weather_code")] public int WeatherCode { get; set; }
    [JsonPropertyName("wind_speed_10m")] public double WindSpeed10m { get; set; }
}

public class DailyUnits
{
    [JsonPropertyName("time")] public string Time { get; set; }
    [JsonPropertyName("weather_code")] public string WeatherCode { get; set; }
    [JsonPropertyName("temperature_2m_max")] public string Temperature2mMax { get; set; }
    [JsonPropertyName("temperature_2m_min")] public string Temperature2mMin { get; set; }
}

public class Daily
{
    [JsonPropertyName("time")] public string[] Time { get; set; }
    [JsonPropertyName("weather_code")] public int[] WeatherCode { get; set; }
    [JsonPropertyName("temperature_2m_max")] public double[] Temperature2mMax { get; set; }
    [JsonPropertyName("temperature_2m_min")] public double[] Temperature2mMin { get; set; }
}