using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Zest.Net.Entities.Client;
using Zest.Net.Entities.Interfaces;
using Zest.Net.Entities.Models;
using Zest.Net.Entities.Repositories;

namespace Zest.Net.Front
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddSingleton(client => new ZestClient(
                new HttpClient { BaseAddress = new Uri("https://zest.srvz-webapp.he-arc.ch/api/") }));
            builder.Services.AddScoped<UserHttpRepository>();
            await builder.Build().RunAsync();
        }
    }
}
