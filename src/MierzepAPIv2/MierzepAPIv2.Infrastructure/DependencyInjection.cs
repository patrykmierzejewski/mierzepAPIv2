using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MierzepAPIv2.Application.Common.Interfaces;
using MierzepAPIv2.Infrastructure.Services;
using System;

namespace MierzepAPIv2.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDateTime, DateTimeService>();

            //File
            services.AddTransient<IFileStore, FileStore.FileStore>();
            services.AddTransient<IFileWrapper, FileStore.FileWrapper>();
            services.AddTransient<IDirectoryWrapper, FileStore.DirectoryWrapper>();

            return services;
        }
    }
}
