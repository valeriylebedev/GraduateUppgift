using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GraduateUppgift.Core.Services
{
    public class ForecastService : IForecastService
    {
        private HttpClient _apiClient;
        private string _apiKey;

        public ForecastService(string apiKey)
        {
            _apiClient = new HttpClient()
            {
                BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/")
            };

            _apiKey = apiKey;
        }

        public async Task<IEnumerable<Forecast>> GetForecastForCity(int cityId)
        {
            var response = await _apiClient.GetAsync($"forecast?id={cityId}&APPID={_apiKey}&units=metric");

            var responseContent = await response.Content.ReadAsStringAsync();

            var forecast = JsonConvert.DeserializeObject<ForecastHead>(responseContent);

            return forecast.list;
        }

        public class Main
        {
            public double temp { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
            public double pressure { get; set; }
            public double sea_level { get; set; }
            public double grnd_level { get; set; }
            public int humidity { get; set; }
            public double temp_kf { get; set; }
        }

        public class Weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class Clouds
        {
            public int all { get; set; }
        }

        public class Wind
        {
            public double speed { get; set; }
            public double deg { get; set; }
        }

        public class Snow
        {
            public double? __invalid_name__3h { get; set; }
        }

        public class Sys
        {
            public string pod { get; set; }
        }

        public class Forecast
        {
            public int dt { get; set; }
            public Main main { get; set; }
            public List<Weather> weather { get; set; }
            public Clouds clouds { get; set; }
            public Wind wind { get; set; }
            public Snow snow { get; set; }
            public Sys sys { get; set; }
            public string dt_txt { get; set; }
        }

        public class Coord
        {
            public double lat { get; set; }
            public double lon { get; set; }
        }

        public class City
        {
            public int id { get; set; }
            public string name { get; set; }
            public Coord coord { get; set; }
            public string country { get; set; }
        }

        public class ForecastHead
        {
            public string cod { get; set; }
            public double message { get; set; }
            public int cnt { get; set; }
            public IEnumerable<Forecast> list { get; set; }
            public City city { get; set; }
        }
    }
}
