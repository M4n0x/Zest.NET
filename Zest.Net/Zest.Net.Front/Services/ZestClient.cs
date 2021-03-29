using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Zest.Net.Front.Extensions;

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
                await http.GetJsonAsync<object>(path, new AuthenticationHeaderValue("Bearer", "token"));
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
