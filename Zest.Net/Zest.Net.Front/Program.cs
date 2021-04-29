using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Radzen;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Zest.Net.Entities.Client;
using Zest.Net.Entities.Repositories;

namespace Zest.Net.Front
{
    /// <summary>
    /// Zest.NET Web Assembly program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args">Zest.NET arguments</param>
        /// <returns>Program</returns>
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddSingleton(client => new ZestClient(
                new HttpClient { BaseAddress = new Uri("https://zest.srvz-webapp.he-arc.ch/api/") }));
            builder.Services.AddScoped<UserHttpRepository>();
            builder.Services.AddScoped<AuthHttpRepository>();
            builder.Services.AddScoped<ResourcesHttpRepository>();
            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<TooltipService>();
            builder.Services.AddScoped<ContextMenuService>();
            builder.Services.AddBlazoredSessionStorage();
            await builder.Build().RunAsync();
        }
    }
}
