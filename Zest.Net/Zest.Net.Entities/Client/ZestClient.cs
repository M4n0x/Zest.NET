using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Zest.Net.Entities.Models;

namespace Zest.Net.Entities.Client
{
    /// <summary>
    /// Http client to use Zest API located at
    /// https://zest.srvz-webapp.he-arc.ch/api/
    /// </summary>
    public class ZestClient
    {
        /// <summary>
        /// Http client
        /// </summary>
        public readonly HttpClient Http;

        /// <summary>
        /// User JWT Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// ZestClient Constructor
        /// </summary>
        /// <param name="http">http client</param>
        public ZestClient(HttpClient http)
        {
            this.Http = http;
        }

        public async Task Login(string username, string password)
        {
            var response = await Http.PostAsJsonAsync("auth/token/", new
            {
                username = username,
                password = password
            });

            var deserializedData = await response.Content.ReadFromJsonAsync<TokenResponse>();
            Token = deserializedData.Access;
        }

        /// <summary>
        /// Method to wrap all API request the same way
        /// </summary>
        /// <typeparam name="TResponse">Response Type</typeparam>
        /// <typeparam name="TBody">Body Request Type</typeparam>
        /// <param name="url">url</param>
        /// <param name="method">Http method</param>
        /// <param name="body">Body content</param>
        /// <returns>Api response</returns>
        private async Task<TResponse> Request<TResponse, TBody>(string url, HttpMethod method, TBody body = null) where TBody : class
        {
            var request = new HttpRequestMessage(method, $"{Http.BaseAddress}{url}");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Token);

            if(body != null)
            {
                request.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
            }

            using var httpResponse = await Http.SendAsync(request);

            return await httpResponse.Content.ReadFromJsonAsync<TResponse>();
        }

        /// <summary>
        /// Method to wrap all API requests the same way
        /// </summary>
        /// <typeparam name="TResponse">Response Type</typeparam>
        /// <param name="url">url</param>
        /// <param name="method">Http method</param>
        /// <returns>Api response</returns>
        private async Task<TResponse> Request<TResponse>(string url, HttpMethod method)
        {
            return await Request<TResponse, object>(url, method, null);
        }

        /// <summary>
        /// Get entities
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="url">url</param>
        /// <returns>Api response</returns>
        public async Task<IEnumerable<TEntity>> Get<TEntity>(string url)
        {
            return await Request<IEnumerable<TEntity>, object>(url, HttpMethod.Get);
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="url">url</param>
        /// <param name="id">entity id</param>
        /// <returns>Api response</returns>
        public async Task<TEntity> GetById<TEntity>(string url, int id)
        {
            return await Request<TEntity>($"{url}/{id}", HttpMethod.Get);
        }

        /// <summary>
        /// Insert an entity
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="url">url</param>
        /// <param name="data">entity to insert</param>
        /// <returns>Api response</returns>
        public async Task Insert<TEntity>(string url, TEntity data)
        {
            await Request<object, object>(url, HttpMethod.Post, data);
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="url">url</param>
        /// <param name="id">Entity id</param>
        /// <param name="data">Data to update entity</param>
        /// <returns>Api response</returns>
        public async Task Update<TEntity>(string url, int id, TEntity data)
        {
            await Request<object, object>($"{url}/{id}", HttpMethod.Post, data);
        }

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="url">url</param>
        /// <param name="id">Entity id to delete</param>
        /// <returns>Api response</returns>
        public async Task Delete<TEntity>(string url, int id)
        {
            await Request<object, object>($"{url}/{id}", HttpMethod.Post);
        }
    }
}
