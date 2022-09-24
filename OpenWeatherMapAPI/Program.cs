using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace OpenWeatherMapAPI
{
    public class CurrentWeather
    {
        public static void Main(string[] args)
        {
            var client = new HttpClient();
            Console.WriteLine("Please enter your personal API key.");
            var apiKey = Console.ReadLine();
            bool conting = true;
            while (conting)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter the city you would like to know the weather for.");
                var cityName = Console.ReadLine();
                var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=imperial";

                var response = client.GetStringAsync(weatherURL).Result;
                var formattedRedponse = JObject.Parse(response).GetValue("main").ToString();
                Console.WriteLine(formattedRedponse);
                Console.WriteLine();
                Console.WriteLine("Would you like to check another city?");
                var userResponse = Console.ReadLine().ToLower();
                if (userResponse == "yes")
                {
                    conting = true;
                }
                else { conting = false; }
            }
        }
    }
}