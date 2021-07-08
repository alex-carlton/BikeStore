using BikeStore.Common.DTO;
using BikeStore.Data;
using BikeStore.Service.Interfaces;
using System.Collections.Generic;

namespace BikeStore.Service
{
    public class BikeService : IBikeService
    {
        private readonly BikeRepository _repository;

        public BikeService()
        {
            _repository = new BikeRepository();
        }

        public BikeDTO GetBike(int bikeId)
        {
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