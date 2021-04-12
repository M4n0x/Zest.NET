using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Zest.Net.Front.Model;

namespace Zest.Net.Front.Client
{
    public class ZestClient
    {
        private readonly HttpClient http;

        private string Token { get; set; }

        public ZestClient(HttpClient http)
        {
            this.http = http;
        }

        public async Task Login(string username, string password)
        {
            var response = await http.PostAsJsonAsync("auth/token/", new
            {
                username = username,
                password = password
            });

            var deserializedData = await response.Content.ReadFromJsonAsync<TokenResponse>();
            Token = deserializedData.Access;
            Console.WriteLine(Token);
        }

        private async Task<TResponse> Request<TResponse, TBody>(string url, HttpMethod method, TBody body = null) where TBody : class
        {
            var request = new HttpRequestMessage(method, $"{http.BaseAddress}{url}");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Token);

            if(body != null)
            {
                request.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
            }

            using var httpResponse = await http.SendAsync(request);

            return await httpResponse.Content.ReadFromJsonAsync<TResponse>();
        }

        public async Task<IEnumerable<TEntity>> Get<TEntity>(string url)
        {
            return await Request<IEnumerable<TEntity>, object>(url, HttpMethod.Get);
        }
    }
}
