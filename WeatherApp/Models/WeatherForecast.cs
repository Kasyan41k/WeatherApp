namespace WeatherApp.Models
{
    public class WeatherForecast
    {
        public string? cod { get; set; }
        public int? message { get; set; }
        public int? cnt { get; set; }
        public City? city { get; set; }
        public IList<WeatherInfo>? list { get; set; }
    }

    public class WeatherInfo
    {
        public int? dt { get; set; }
        public WeatherInfoMain? main { get; set; }
        public WeatherInfoWind? wind { get; set; }
        public IList<WeatherInfoWeatherItem>? weather { get; set; }
        public string? dt_txt { get; set; }
    }

    public class WeatherInfoMain
    {
        public double? temp { get; set; }
        public double? feels_like { get; set; }
        public double? temp_min { get; set; }
        public double? temp_max { get; set; }
        public int? pressure { get; set; }
        public int? sea_level { get; set; }
        public int? grnd_level { get; set; }
        public int? humidity { get; set; }
        public double? temp_kf { get; set; }
    }

    public class WeatherInfoWind
    {
        public double? speed { get; set; }
        public int? deg { get; set; }
        public double? gust { get; set; }
    }

    public class WeatherInfoWeatherItem
    {
        public int? id { get; set; }
        public string? main { get; set; }
        public string? description { get; set; }
        public string? icon { get; set; }
    }

    public class City
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public Coord? coord { get; set; }
        public string? country { get; set; }
        public int? population { get; set; }
        public int? timezone { get; set; }
        public int? sunrise { get; set; }
        public int? sunset { get; set; }
    }

    public class Coord
    {
        public double? lat { get; set; }
        public double? lon { get; set; }
    }
}