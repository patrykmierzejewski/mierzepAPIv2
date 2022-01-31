using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MierzepAPIv2.Persistance
{
    /// <summary>
    /// DBContext Factory - pozwoli uniknąć błędów dla DB Context 
    /// Migracje są realizowane w trybie designTime a nie w trybie runtime.
    /// Migracje będą ok.
    /// Błędy mogą wynikać z drobnych zmian w enetity Framework Core.
    /// </summary>
    public abstract class DesignTimeDbContextFactoryBase<TContext> :
        IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        private const string ConnectionString = "TextDB";
        private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";

        public TContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory() + string.Format("{0}..{0}MierzepAPIv2", Path.DirectorySeparatorChar);
            return Create(basePath, Environment.GetEnvironmentVariable(AspNetCoreEnvironment));
        }

        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

        private TContext Create(string basePath, string environmentName)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Local.json", optional: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetConnectionString(ConnectionString);

            return Create(connectionString);
        }

        private TContext Create(string connectionString)
        {
            if (String.IsNullOrEmpty(connectionString))
                throw new ArgumentException($"Connection string '{connectionString}' is null or empty", nameof(connectionString));

            Console.WriteLine($"DesignTimeDbContextFactoryBase.Create(string): Connection string: '{connectionString}'.");

            var optionsBuilder = new DbContextOptionsBuilder<TContext>();

            
            optionsBuilder.UseSqlServer(connectionString); // use sql SERVER, is accept other database
            

            return CreateNewInstance(optionsBuilder.Options);
        }

    }
}
