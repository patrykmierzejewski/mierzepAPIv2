using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MierzepAPIv2.Application.Common.Interfaces;
using MierzepAPIv2.ExternalAPI.ExternalAPI.OMDB;
using System;
using System.Net.Http;

namespace MierzepAPIv2.ExternalAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddExternalAPI(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //SET External Client
            serviceCollection.AddHttpClient("OmdbClient", options => 
            {
                options.BaseAddress = new Uri("http://www.omdbapi.com"); //set address to appsettings for IConfiguration
                options.Timeout = new TimeSpan(0, 0, 15);
                options.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            }).ConfigurePrimaryHttpMessageHandler(sp => new HttpClientHandler());


            serviceCollection.AddScoped<IOmdbClient, OmdbClient>();

            return serviceCollection;
        }
    }
}
