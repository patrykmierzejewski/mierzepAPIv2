using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MierzepAPIv2.Application.Common.Behaviours;
using System;
using System.Reflection;

namespace MierzepAPIv2.Application
{
    /// <summary>
    /// Contaner IoC
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //AutoMapper Set
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //Validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            //Behaviours Logging, validations
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>)); //TRequest, TResponse
            services.AddTransient(typeof(IRequestPreProcessor<>), typeof(LoggingBehaviour<>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));

            return services;
        }
    }
}
