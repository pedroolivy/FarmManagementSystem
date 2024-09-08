using FarmManagementSystem.Domain.Interfaces;
using FarmManagementSystem.Services.Services;
using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Services.Dtos;
using FluentAssertions;
using Moq;

namespace FarmManagementSystem.Tests.ServicesTests
{
    public class FarmServiceTests
    {
        private readonly Mock<ILocationRepository> _locationRepositoryMock;
        private readonly Mock<IFarmRepository> _farmRepositoryMock;
        private readonly FarmService _farmService;

        public FarmServiceTests()
        {
            _locationRepositoryMock = new Mock<ILocationRepository>();
            _farmRepositoryMock = new Mock<IFarmRepository>();
            _farmService = new FarmService(_farmRepositoryMock.Object, _locationRepositoryMock.Object);
        }

        [Fact]
        public void GetById_Should_Return_Correct_Farm()
        {
            //Arrange
            var farm = new Farm { Id = 9};
            _farmRepositoryMock.Setup(repo => repo.GetById(farm.Id)).Returns(farm);

            //Act
            var result = _farmService.GetById(farm.Id);

            //Assert
            result.Should().BeEquivalentTo(farm);
        }

        [Fact]
        public void GetById_ShouldThrowValidationException_WhenFarmNotFound()
        {
            //Arrange
            var farm = new Farm {Id = 1};
            _farmRepositoryMock.Setup(repo => repo.GetById(farm.Id)).Returns((Farm)null);

            //Act
            var reuslt = () => _farmService.GetById(farm.Id);

            //Assert
            reuslt.Should().Throw<Exception>().WithMessage("Não existem registros dessa fazenda em nosso sistemma.");
        }

        [Fact]
        public void Add_ShouldCallRepositoryAdd_WhenFarmIsValid()
        {
            var farmDto = new FarmDto
            {
                Id = 9,
                UserId = 4,
                Name = "Green Valley Farm",
                Description = "A sustainable farm focusing on organic crops",
                DateAdd = DateTime.Now.AddDays(1),
                FarmIsActive = true,
                Location = new LocationDto
                {
                    Id = 0,
                    Latitude = 50.0,
                    Longitude = 50.0,
                },
            };

            _farmRepositoryMock.Setup(repo => repo.Add(It.IsAny<Farm>()));

            //Act
            _farmService.Add(farmDto);

            //Assert
            _farmRepositoryMock.Verify(repo => repo.Add(It.IsAny<Farm>()), Times.Once);
        }

        [Fact]
        public void Add_ShouldThrowException_WhenRepositoryThrowsException()
        {
            {
                // Arrange
                var farmDto = new FarmDto
                {
                    Id = 9,
                    UserId = 4,
                    Name = "Green Valley Farm",
                    Description = "A sustainable farm focusing on organic crops",
                    DateAdd = DateTime.Now.AddDays(1),
                    FarmIsActive = true,
                    Location = new LocationDto
                    {
                        Id = 0,
                        Latitude = 50.0,
                        Longitude = 50.0,
                    },
                };

                _farmRepositoryMock.Setup(repo => repo.Add(It.IsAny<Farm>())).Throws(new Exception("Database Error"));

                // Act & Assert
                Assert.Throws<Exception>(() => _farmService.Add(farmDto));
            }
        }

        [Fact]
        public void Update_ShouldCallRepositoryUpdate_WhenFarmIsValid()
        {
            {
                // Arrange
                var farmDto = new FarmDto
                {
                    Id = 9,
                    UserId = 4,
                    Name = "Black Valley Farm",
                    Description = "A sustainable farm focusing on crops",
                    DateAdd = DateTime.Now.AddDays(1),
                    FarmIsActive = true,
                    Location = null
                };

                var farm = new Farm
                {
                    Id = 9,
                    UserId = 4,
                    Name = "Green Valley Farm",
                    Description = "A sustainable farm focusing on organic crops",
                    DateAdd = DateTime.Now.AddDays(1),
                    FarmIsActive = true,
                    Location = null,
                    Crops = null,
                    Animals = null,
                    Employees = null
                };

                _farmRepositoryMock.Setup(repo => repo.GetById(farm.Id)).Returns(farm);
                
                // Act
                _farmService.Update(farmDto);

                // Assert
                _farmRepositoryMock.Verify(repo => repo.Update(It.IsAny<Farm>(), It.IsAny<Farm>()), Times.Once);
            }
        }

        [Fact]
        public void Update_ShouldThrowValidationException_WhenFarmIsInactive()
        {
            {
                // Arrange
                var farmDto = new FarmDto
                {
                    Id = 9,
                    UserId = 4,
                    Name = "Green Valley Farm",
                    Description = "A sustainable farm focusing on organic crops",
                    DateAdd = DateTime.Now.AddDays(1),
                    FarmIsActive = false,
                    Location = null
                };

                var farm = new Farm
                {
                    Id = 9,
                    UserId = 4,
                    Name = "Green Valley Farm",
                    Description = "A sustainable farm focusing on organic crops",
                    DateAdd = DateTime.Now.AddDays(1),
                    FarmIsActive = false,
                    Location = null,
                    Crops = null,
                    Animals = null,
                    Employees = null
                };

                _farmRepositoryMock.Setup(repo => repo.GetById(farm.Id)).Returns(farm);

                // Act & Assert
                Assert.Throws<Exception>(() => _farmService.Update(farmDto));
            }
        }

        [Fact]
        public void Update_ShouldThrowException_WhenRepositoryThrowsException()
        {
            // Arrange
            var farmDto = new FarmDto { Id = 1 };
            _farmRepositoryMock.Setup(repo => repo.GetById(farmDto.Id)).Throws(new Exception("Database Error"));

            // Act & Assert
            Assert.Throws<Exception>(() => _farmService.Update(farmDto));
        }

    }
}