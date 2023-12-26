namespace WeatherAppPCP.Models
{
    public class WeatherForecastSimplified
    {

        public string? DataTimeText { get; private set; }
        public double? Temperature { get; private set; }
        public double? WindSpeed { get; private set; }
        public string? WeatherMain { get; private set; }
        public string? WeatherDescription { get; private set; }
        public string? City { get; private set; }

        public WeatherForecastSimplified(string? dataTimeText, double? temperature, double? windSpeed, string? weatherMain, string? weatherDescription, string? city)
        {
            DataTimeText = dataTimeText;
            Temperature = temperature;
            WindSpeed = windSpeed;
            WeatherMain = weatherMain;
            WeatherDescription = weatherDescription;
            City = city;
        }

        public override string ToString()
        {
            return $"City: {City}; DataTime: {DataTimeText}; Temperature: {Temperature}; Wind speed: {WindSpeed}; Weather main: {WeatherMain}; Weather description: {WeatherDescription};";
        }
    }
}
