using WeatherAppPCP.Models;

namespace WeatherAppPCP
{
    public class Program
    {
        private static ApiManager? _apiHandler;
        private static DatabaseCreator? _dbManager;

        public static async Task Main(string[] args)
        {
            _apiHandler = new ApiManager();
            _dbManager = new DatabaseCreator();
            _dbManager.CreateTableIfNotExist();

            Console.WriteLine("Enter City name:");
            string cityName = Console.ReadLine();

            GetData(cityName);
            PrintData();

            Console.ReadKey();
        }
        private static void GetData(string cityName)
        {
            WeatherForecast wf = _apiHandler.GetData(cityName).Result;
            _dbManager.InsertData(new WeatherForecastSimplified(wf.list[0].dt_txt, wf.list[0].main.temp, wf.list[0].wind.speed, wf.list[0].weather[0].main, wf.list[0].weather[0].description,wf.city.name));
        }

        private static void PrintData()
        {
            List<WeatherForecastSimplified> data = _dbManager.ReadData();
            foreach (var dataItem in data)
            {
                Console.WriteLine(dataItem);
            }
        }
    }
}