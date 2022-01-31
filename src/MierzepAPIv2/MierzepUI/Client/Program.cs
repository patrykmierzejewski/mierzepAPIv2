using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace MierzepUI.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("gpt3", options =>
            {
                options.BaseAddress = new Uri("https://api.openai.com/v1/engines/text-davinci-001/completions"); //set address to appsettings for IConfiguration
                options.Timeout = new TimeSpan(0, 0, 15);
                options.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            }).ConfigurePrimaryHttpMessageHandler(sp => new HttpClientHandler());

            //builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("api"));
            builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("gpt3"));
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            //builder.Services.AddOidcAuthentication(options =>
            //{
            //    builder.Configuration.Bind("oidc", options.ProviderOptions);
            //});

            builder.Services.AddSpeechSynthesis();

            await builder.Build().RunAsync();
        }
    }
}
