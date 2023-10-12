using System.Text.Json;
using WeatherApp.Models;

namespace WeatherApp
{
    public class ApiManager
    {
        private const string ApiUrl = "https://api.openweathermap.org/data/2.5/forecast?appid=cfe6f3c246e8d6bb3268b51fcc7ff430&q=London&units=metric&cnt=5";

        public async Task<WeatherForecast> GetData()
        {
            using (HttpClient client = new HttpClient())
            {
                var responseMessage = await client.GetStringAsync(ApiUrl);
                var weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(responseMessage);
                return weatherForecast;
            }
        }
    }
}