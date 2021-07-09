using BikeStore.Common.DTO;
using BikeStore.Data.Interfaces;
using BikeStore.Service.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace BikeStore.Service
{
    public class BikeService : IBikeService
    {
        private readonly ILogger<BikeService> _log;
        private readonly IBikeRepository _repository;

        public BikeService(ILogger<BikeService> log, IBikeRepository repoistory)
        {
            _log = log;
            _repository = repoistory;
        }

        public BikeDTO GetBike(int bikeId)
        {
            _log.LogInformation("File: BikeService Function: GetBike");

            BikeDTO bike = _repository.GetBike(bikeId);

            // Business Rules
            if (bike.SerialNumber.Contains("Testing"))
            {
                bike.Price -= 100;
            }

            return bike;
        }

        public List<BikeDTO> GetBikes()
        {
            throw new System.NotImplementedException();
        }
    }
}