using BikeStore.Data.Interfaces;
using BikeStore.Service.Interfaces;
using FakeItEasy;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace BikeStore.Service.Tests
{
    [TestFixture]
    public class BikeServiceTests
    {
        private IBikeService _service;
        private IBikeRepository _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = A.Fake<IBikeRepository>();
            _service = new BikeService(new NullLogger<BikeService>(), _repository);
        }

        [Test]
        public void IsDiscountApplied_Success()
        {
            // Arrange 
            A.CallTo(() => _repository.GetBike(A<int>.Ignored)).Returns(
                new Common.DTO.BikeDTO()
                {
                    BikeId = 1234,
                    Price = 299.99M,
                    Name = "Extreme Mountain",
                    SerialNumber = "Testing-1234",
                    Category = Common.Enums.BikeCategoryEnum.Mountain,
                }
            );

            // Act 
            var result = _service.GetBike(1);

            // Assert
            Assert.IsTrue(result.Price == 199.99M);
        }

        [Test]
        public void IsDiscountApplied_Failure()
        {
            // Arrange 
            A.CallTo(() => _repository.GetBike(A<int>.Ignored)).Returns(
                new Common.DTO.BikeDTO()
                {
                    BikeId = 1234,
                    Price = 299.99M,
                    Name = "Extreme Mountain",
                    SerialNumber = "Test-1234",
                    Category = Common.Enums.BikeCategoryEnum.Mountain,
                }
            );

            // Act 
            var result = _service.GetBike(1);

            // Assert
            Assert.IsFalse(result.Price == 199.99M);
        }
    }
}