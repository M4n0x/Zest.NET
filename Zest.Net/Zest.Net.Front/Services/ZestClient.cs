using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Zest.Net.Front.Services
{
    public class ZestClient
    {
        private readonly HttpClient http;

        public ZestClient(HttpClient http)
        {
            this.http = http;
        }

        public async Task<object[]> GetAsync(string path = "")
        {
            object[] forecasts = null;
            try
            {
                forecasts = await http.GetFromJsonAsync<object[]>(
                    "WeatherForecast");
            }
            catch
            {
                // TODO
            }

            return forecasts;
        }
    }
}
