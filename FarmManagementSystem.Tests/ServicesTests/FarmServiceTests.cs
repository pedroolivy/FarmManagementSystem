using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Domain.Enums;
using FarmManagementSystem.Domain.Interfaces;
using FarmManagementSystem.Services.Services;
using FluentAssertions;
using Moq;

namespace FarmManagementSystem.Tests.ServicesTests
{
    public class FarmServiceTests
    {
        [Fact]
        public void GetFarmById_Should_Return_Correct_Farm()
        {
            //Arrange
            var farm = new Farm
            {
                Id = 9,
                UserId = 4,
                Name = "Green Valley Farm",
                Description = "A sustainable farm focusing on organic crops",
                DateAdd = DateTime.Parse("02/09/2024 20:58:02"), 
                FarmIsActive = true,
                Location = null,
                Crops = null,
                Animals = null,
                Employees = null
            };

            //Mock
            var mockFarmRepo = new Mock<IFarmRepository>();
            var mockLocationRepo = new Mock<ILocationRepository>();
            var farmService = new FarmService(mockFarmRepo.Object, mockLocationRepo.Object);

            //Act
            var result = farmService.GetById(farm.Id);

            //Assert
            result.Should().BeEquivalentTo(farm);
        }
    }
}