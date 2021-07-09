using BikeStore.Data;
using BikeStore.Data.Interfaces;
using BikeStore.Service;
using BikeStore.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.IO;

namespace BikeStore.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            BuildConfig(builder);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IBikeStore, BikeStore>();
                    services.AddTransient<IBikeService, BikeService>();
                    services.AddTransient<IBikeRepository, BikeRepository>();
                })
                .UseSerilog()
                .Build();

            BikeStore bikeStore = ActivatorUtilities.CreateInstance<BikeStore>(host.Services);
            bikeStore.Start();
        }

        private static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        }
    }
}