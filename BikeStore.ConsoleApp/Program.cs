using BikeStore.Service;
using System;

namespace BikeStore.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Ask user for input
            Console.WriteLine("Welcome to the Bike Store");
            Console.WriteLine("Please enter your BikeId (Numeric):");

            // Reads input from user and checks int type
            int bikeId = Int32.Parse(Console.ReadLine());

            BikeService bicycleService = new BikeService();

            Common.DTO.BikeDTO bikeDto = bicycleService.GetBike(bikeId);

            Console.WriteLine($"BikeId: {bikeDto.BikeId}");
            Console.WriteLine($"Name: {bikeDto.Name}");
            Console.WriteLine($"Price: {bikeDto.Price}");
            Console.WriteLine($"Category: {bikeDto.Category}");
            Console.WriteLine($"Serial Number: {bikeDto.SerialNumber}");
        }
    }
}