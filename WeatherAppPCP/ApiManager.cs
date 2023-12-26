using System.Text.Json;
using WeatherAppPCP.Models;

namespace WeatherAppPCP
{
    public class ApiManager
    {
        public async Task<WeatherForecast> GetData(string cityName)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"https://api.openweathermap.org/data/2.5/forecast?appid=cfe6f3c246e8d6bb3268b51fcc7ff430&q={cityName}&units=metric&cnt=5";
                var responseMessage = await client.GetStringAsync(apiUrl);
                var weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(responseMessage);
                return weatherForecast;
            }
        }
    }
}
