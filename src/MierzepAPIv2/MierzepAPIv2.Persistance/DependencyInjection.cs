using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MierzepAPIv2.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MierzepAPIv2.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TextDBContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("TextDB")));
            services.AddScoped<ITextDbContext, TextDBContext>();

            return services;
        }
    }
}
