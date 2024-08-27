using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace FarmManagementSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmController : ControllerBase
    {
        private readonly FarmService _farmService;

        public FarmController(FarmService farmService)
        {
            _farmService = farmService;
        }

        [HttpGet("farms")]
        public OkObjectResult GetAll()
        {
            var farms = _farmService.GetAll();
            return Ok(farms);
        }

        [HttpGet("farm/{Id}")]
        public OkObjectResult GetById(int Id)
        {
            var farm = _farmService.GetById(Id);
            return Ok(farm);
        }

        [HttpGet("farmByUserId/{Id}")]
        public OkObjectResult GetByUserId(int Id)
        {
            var farms = _farmService.GetByUserId(Id);
            return Ok(farms);
        }

        [HttpPost("farm")]
        public CreatedResult Add([FromBody] Farm farm)
        {
            _farmService.Add(farm);
            return Created();
        }

        [HttpPut("farmUpdate")]
        public OkResult Update([FromBody] Farm farm)
        {
            _farmService.Update(farm);
            return Ok();
        }

        [HttpDelete("farm/{id}")]
        public OkResult Delete(int id)
        {
            _farmService.Delete(id);
            return Ok();
        }
    }
}
