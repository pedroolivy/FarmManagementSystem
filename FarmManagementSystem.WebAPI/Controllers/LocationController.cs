using FarmManagementSystem.Domain.Entities;
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

        [HttpPost("location")]
        public CreatedResult Add([FromBody] Location location)
        {
            _locationService.Add(location);
            return Created();
        }

        [HttpPut("locationUpdate")]
        public OkResult Update([FromBody] Location location)
        {
            _locationService.Update(location);
            return Ok();
        }

        [HttpDelete("location/{id}")]
        public OkResult Delete(int id)
        {
            _locationService.Delete(id);
            return Ok();
        }
    }
}
