using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MierzepAPIv2.Application;
using MierzepAPIv2.ExternalAPI;
using MierzepAPIv2.Infrastructure;
using MierzepAPIv2.Persistance;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MierzepAPIv2
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //DI INFRASTRUCTURE
            services.AddInfrastructure(Configuration);
            services.AddPersistance(Configuration);

            //DI CORE

            //DI Application
            services.AddApplication(Configuration);

            //DI ExternalAPI
            services.AddExternalAPI(Configuration);

            //Set CORS
            services.AddCors(options =>
            {
                //First policy
                options.AddPolicy(name: "MyAllowSpecificOrgins",
                    builder => 
                    { 
                        builder.WithOrigins("https://localhost:4222, https://robot:4223");
                    });


                //Second policy - To DO
            });

            services.AddControllers();

            //Set your Info
            services.AddSwaggerGen(c =>
            {
                //Set your documentation API
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "MierzepAPIv2",
                    Version = "v1",
                    Description = "This is simple description WebAPI Onion Architecutre - optional set description for your app",
                    TermsOfService = new Uri("https://mierzep.example.com/terms"),
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Name = "Patryk Mierzejewski",
                        Email = "mierzep@gmail.com",
                        Url = new Uri("https://mierzep.com")
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense()
                    {
                        Name = "Used License",
                        Url = new Uri("https://example.mierzep/license")
                    }
                });

                //summary comments in controllers
                var filePath = Path.Combine(AppContext.BaseDirectory, "MierzepAPIv2.xml");
                c.IncludeXmlComments(filePath);
            });

            //Controllers HealthChecks
            services.AddHealthChecks();
        }
           
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //add swagger for debug version, if API enable Public ? add swagger for without env.IsDevelopment()
                app.UseSwagger();

                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MierzpAPIv2"));

                app.UseDeveloperExceptionPage();
            }

            //Health check controller set url address.
            app.UseHealthChecks("/hc");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            //CORS After definition - UseRouting, Before def - UseAuthorization
            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
