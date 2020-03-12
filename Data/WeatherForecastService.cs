using GridMvc.Server;
using GridShared;
using GridShared.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTest.Data {
    public class WeatherForecastService {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public ItemsDTO<WeatherForecast> GetForecastAsync(Action<IGridColumnCollection<WeatherForecast>> columns, QueryDictionary<StringValues> query) {
            DateTime startDate = DateTime.Now; 
            var rng = new Random();
            var arr = Enumerable.Range(1, 5).Select(index => new WeatherForecast {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
            var server = new GridServer<WeatherForecast>(arr, new QueryCollection(query),
                true, "RegistrationsGrid", columns, 10)
                .Sortable();
            return server.ItemsToDisplay;
        }
    }
}
