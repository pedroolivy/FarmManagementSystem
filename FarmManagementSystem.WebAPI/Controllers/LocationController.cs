using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Services.Dtos;
using FarmManagementSystem.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace FarmManagementSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly LocationService _locationService;

        public LocationController(LocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("locations")]
        public OkObjectResult GetAll()
        {
            var locations = _locationService.GetAll();
            return Ok(locations);
        }

        [HttpGet("location/{Id}")]
        public OkObjectResult GetById(int Id)
        {
            var location = _locationService.GetById(Id);
            return Ok(location);
        }

        [HttpGet("locationByfarmId/{Id}")]
        public OkObjectResult GetByFarmId(int Id)
        {
            var locations = _locationService.GetByFarmId(Id);
            return Ok(locations);
        }

        [HttpPut("locationUpdate")]
        public OkResult Update([FromBody] LocationDto locationDto)
        {
            _locationService.Update(locationDto);
            return Ok();
        }
    }
}
