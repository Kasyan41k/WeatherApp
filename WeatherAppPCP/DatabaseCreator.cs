using System;
using System.Text;
using WeatherAppPCP.Models;
using System.Data.SQLite;
using System.Data;

namespace WeatherAppPCP
{
    public class DatabaseCreator
    {
        private const string ConnectionString = "Data Source=database.db; Version = 3; New = True; Compress = True;";

        private readonly SQLiteConnection _sqLiteConnection;

        public DatabaseCreator()
        {
            _sqLiteConnection = new SQLiteConnection(ConnectionString);
            
            _sqLiteConnection.Open();
        }

        public void CreateTableIfNotExist()
        {
            SQLiteCommand sqLiteCommand = _sqLiteConnection.CreateCommand();
            sqLiteCommand.CommandText = "CREATE TABLE IF NOT EXISTS WeatherForecast (" +
                                        "dt_text VARCHAR(20), " +
                                        "temp NUMERIC, " +
                                        "wind_speed NUMERIC, " +
                                        "weather_main TEXT, " +
                                        "weather_description TEXT, " +
                                        "city TEXT" +
                                        ")";
            sqLiteCommand.ExecuteNonQuery();
        }

        public void InsertData(WeatherForecastSimplified wfs)
        {
            string insertQuery = "INSERT INTO WeatherForecast (dt_text, temp, wind_speed, weather_main, weather_description, city) VALUES(@dtText, @temp, @windSpeed, @weatherMain, @weatherDescription, @city)";

            using (SQLiteCommand command = new SQLiteCommand(insertQuery, _sqLiteConnection))
            {
                var parameters = new List<SQLiteParameter>
        {
            new SQLiteParameter("@dtText", DbType.String) { Value = wfs.DataTimeText },
            new SQLiteParameter("@temp", DbType.Double) { Value = wfs.Temperature },
            new SQLiteParameter("@windSpeed", DbType.Double) { Value = wfs.WindSpeed },
            new SQLiteParameter("@weatherMain", DbType.String) { Value = wfs.WeatherMain },
            new SQLiteParameter("@weatherDescription", DbType.String) { Value = wfs.WeatherDescription },
            new SQLiteParameter("@city", DbType.String) { Value = wfs.City }
        };

                command.Parameters.AddRange(parameters.ToArray());
                command.ExecuteNonQuery();
            }
        }


        public List<WeatherForecastSimplified> ReadData()
        {
            SQLiteCommand sqLiteCommand = _sqLiteConnection.CreateCommand();
            sqLiteCommand.CommandText = "SELECT * FROM WeatherForecast";
            SQLiteDataReader sqLiteDataReader = sqLiteCommand.ExecuteReader();
            List<WeatherForecastSimplified> data = new List<WeatherForecastSimplified>();
            while (sqLiteDataReader.Read())
            {
                data.Add(new WeatherForecastSimplified(
                    sqLiteDataReader.GetString(0),
                    sqLiteDataReader.GetDouble(1),
                    sqLiteDataReader.GetDouble(2),
                    sqLiteDataReader.GetString(3),
                    sqLiteDataReader.GetString(4),
                    sqLiteDataReader.GetString(5)
                    ));
            }

            return data;
        }
    }
}
