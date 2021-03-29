using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace Zest.Net.Front.Extensions
{
    public static class ServicesExtensions
    {

        public static async Task<T> GetJsonAsync<T>(this HttpClient httpClient, string url, AuthenticationHeaderValue authorization)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = authorization;

            var response = await httpClient.SendAsync(request);
            var responseBytes = await response.Content.ReadAsByteArrayAsync();
            return JsonSerializer.Deserialize<T>(responseBytes, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }
    }
}
