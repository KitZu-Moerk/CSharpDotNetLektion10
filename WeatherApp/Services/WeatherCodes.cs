namespace WeatherApp.Services;

public class WeatherCodes
{
    private readonly Dictionary<int, string> _weatherCodes = new()
    {
        { 0, "Klar himmel" },
        { 1, "Hovedsageligt klart" },
        { 2, "Delvist skyet" },
        { 3, "Overskyet" },
        { 45, "Tåge" },
        { 48, "Rimtåge" },
        { 51, "Let støvregn" },
        { 53, "Moderat støvregn" },
        { 55, "Tæt støvregn" },
        { 56, "Let underafkølet støvregn" },
        { 57, "Tæt underafkølet støvregn" },
        { 61, "Let regn" },
        { 63, "Moderat regn" },
        { 65, "Kraftig regn" },
        { 66, "Let underafkølet regn" },
        { 67, "Kraftig underafkølet regn" },
        { 71, "Let snefald" },
        { 73, "Moderat snefald" },
        { 75, "Kraftigt snefald" },
        { 77, "Snegryn" },
        { 80, "Lette regnbyger" },
        { 81, "Moderate regnbyger" },
        { 82, "Voldsomme regnbyger" },
        { 85, "Lette snebyger" },
        { 86, "Kraftige snebyger" },
        { 95, "Tordenvejr: let eller moderat" },
        { 96, "Tordenvejr med let hagl" },
        { 99, "Tordenvejr med kraftigt hagl" }
    };
    
    public string GetWeatherDescription(int code) => _weatherCodes.GetValueOrDefault(code, "Ukendt vejrkode");
}