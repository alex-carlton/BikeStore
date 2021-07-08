using BikeStore.Common.DTO;
using System.Collections.Generic;

namespace BikeStore.Service.Interfaces
{
    public interface IBikeService
    {
        /// <summary>
        /// Get Single Bike Information
        /// </summary>
        /// <param name="bikeId">Bike Identifier</param>
        BikeDTO GetBike(int bikeId);

        /// <summary>
        /// Get Collection of Bike Information
        /// </summary>
        List<BikeDTO> GetBikes();
    }
}