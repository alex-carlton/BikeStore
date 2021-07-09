using BikeStore.Service;
using BikeStore.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace BikeStore.ConsoleApp
{
    public interface IBikeStore
    {
        /// <summary>
        /// Starts the UI of the Bike Store console application
        /// </summary>
        void Start();
    }

    public class BikeStore : IBikeStore
    {
        private readonly ILogger<BikeStore> _log;
        private readonly IConfiguration _config;
        private readonly IBikeService _service;

        public BikeStore(ILogger<BikeStore> log, IConfiguration config, IBikeService service)
        {
            _log = log;
            _config = config;
            _service = service;
        }

        public void Start()
        {
            _log.LogInformation($"{_config.GetValue<string>("ExampleConfigSetting")}");

            // Ask user for input
            Console.WriteLine("Welcome to the Bike Store");
            Console.WriteLine("Please enter your BikeId (Numeric):");

            // Reads input from user and checks int type
            int bikeId = Int32.Parse(Console.ReadLine());

            Common.DTO.BikeDTO bikeDto = _service.GetBike(bikeId);

            Console.WriteLine($"BikeId: {bikeDto.BikeId}");
            Console.WriteLine($"Name: {bikeDto.Name}");
            Console.WriteLine($"Price: {bikeDto.Price}");
            Console.WriteLine($"Category: {bikeDto.Category}");
            Console.WriteLine($"Serial Number: {bikeDto.SerialNumber}");
        }
    }
}
