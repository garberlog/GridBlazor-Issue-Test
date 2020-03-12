using GridShared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BugTest.Data {
    public class CRUDService : ICrudDataService<WeatherForecast> {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<WeatherForecast> Get(params object[] keys) {
            DateTime startDate = DateTime.Now;
            var rng = new Random();
            return new WeatherForecast {
                Date = startDate.AddDays(1),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            };
        }

        public async Task Insert(WeatherForecast item) {

        }

        public async Task Update(WeatherForecast item) {

        }

        public async Task Delete(params object[] keys) {

        }
    }
}
