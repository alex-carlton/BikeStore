using BikeStore.Common.DTO;
using BikeStore.Common.Enums;
using BikeStore.Data.Interfaces;
using System.Collections.Generic;

namespace BikeStore.Data
{
    public class BikeRepository : IBikeRepository
    {
        public BikeRepository()
        {
        }

        //TODO: Add data connection, currently just a mocked return.
        public BikeDTO GetBike(int bikeId)
        {
            return new BikeDTO
            {
                BikeId = bikeId,
                Name = "Bike-Test",
                SerialNumber = "Testing-1234",
                Category = BikeCategoryEnum.Road,
                Price = 599.99M
            };
        }

        public List<BikeDTO> GetBikes()
        {
            throw new System.NotImplementedException();
        }
    }
}