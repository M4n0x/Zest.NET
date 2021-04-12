﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Zest.Net.Entities.Models;

namespace Zest.Net.Entities.Client
{
    public class ZestClient
    {
        public readonly HttpClient Http;

        public string Token { get; set; }

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

        private async Task<TResponse> Request<TResponse>(string url, HttpMethod method)
        {
            return await Request<TResponse, object>(url, method, null);
        }

        public async Task<IEnumerable<TEntity>> Get<TEntity>(string url)
        {
            return await Request<IEnumerable<TEntity>, object>(url, HttpMethod.Get);
        }

        public async Task<TEntity> GetById<TEntity>(string url, int id)
        {
            return await Request<TEntity>($"{url}/{id}", HttpMethod.Get);
        }

        public async Task Insert<TEntity>(string url, TEntity data)
        {
            await Request<object, object>(url, HttpMethod.Post, data);
        }

        public async Task Update<TEntity>(string url, int id, TEntity data)
        {
            await Request<object, object>($"{url}/{id}", HttpMethod.Post, data);
        }

        public async Task Delete<TEntity>(string url, int id)
        {
            await Request<object, object>($"{url}/{id}", HttpMethod.Post);
        }
    }
}
