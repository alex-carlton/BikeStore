using BikeStore.Common.Enums;

namespace BikeStore.Common.DTO
{
    public class BikeDTO
    {
        public int BikeId { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public decimal Price { get; set; }
        public BikeCategoryEnum Category { get; set; }
    }
}