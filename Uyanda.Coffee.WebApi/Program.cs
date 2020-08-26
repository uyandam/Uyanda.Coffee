using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Uyanda.Coffee.Application;
using Uyanda.Coffee.Persistence;

namespace Uyanda.Coffee.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((context, builder) => RegisterLogging(builder))
                .ConfigureAppConfiguration((context, builder) => RegisterConfigurations(builder))
                .ConfigureServices((context, collection) => RegisterServices(context.Configuration, collection))
                .UseStartup<Startup>();
        }

        private static void RegisterLogging(ILoggingBuilder loggingBuilder)
        {

        }

        private static void RegisterConfigurations(IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile("appsettings.dev.json", true)
                .AddEnvironmentVariables();
        }

        private static void RegisterServices(IConfiguration configuration, IServiceCollection serviceCollection)
        {
            // Applicatoin Settings

            // Application Modules
            serviceCollection.AddApplicationModule()
                .AddPersistenceModule();

            // AutoMapper
            serviceCollection.AddTransient(_ => Mapper());
        }

        private static IMapper Mapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(PersistenceModule));
            });

            config.AssertConfigurationIsValid();

            config.CompileMappings();

            return config.CreateMapper();
        }
    }
}
