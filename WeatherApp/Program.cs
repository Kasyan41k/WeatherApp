using WeatherApp.Models;

namespace WeatherApp
{
    public class Program
    {
        private static ApiManager? _apiHandler;
        private static DBCreator? _dbManager;
        
        public static async Task Main(string[] args)
        {
            _apiHandler = new ApiManager();
            _dbManager = new DBCreator();
            _dbManager.CreateTableIfNotExist();
            
            await HandleInput();
        }

        private static async Task HandleInput()
        {
            while (true)
            {
                await Console.Out.WriteLineAsync("Type 'get' to get information, 'print' to see weather or 'exit' to exit the program");
                 
                string input = Console.ReadLine();

                switch (input)
                {
                    case "get":
                        GetData();
                        break;
                    case "print":
                        PrintData();
                        break;
                    case "exit":
                        return;
                    default:
                        break;
                }
            }
        }

        private static void GetData()
        {
            WeatherForecast wf = _apiHandler.GetData().Result;
            _dbManager.InsertData(new WeatherForecastShort(
                wf.list[0].dt_txt, 
                wf.list[0].main.temp, 
                wf.list[0].wind.speed, 
                wf.list[0].weather[0].main, 
                wf.list[0].weather[0].description,
                wf.city.name
                ));
        }

        private static void PrintData()
        {
            List<WeatherForecastShort> data = _dbManager.ReadData();
            foreach (var dataItem in data)
            {
                Console.WriteLine(dataItem);
            }
        }
    }
}