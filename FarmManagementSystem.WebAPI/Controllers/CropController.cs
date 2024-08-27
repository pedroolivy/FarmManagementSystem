using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace FarmManagementSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CropController : ControllerBase
    {
        private readonly CropService _cropService;

        public CropController(CropService cropService)
        {
            _cropService = cropService;
        }

        [HttpGet("crops")]
        public OkObjectResult GetAll()
        {
            var crops = _cropService.GetAll();
            return Ok(crops);
        }

        [HttpGet("crop/{Id}")]
        public OkObjectResult GetById(int Id)
        {
            var crop = _cropService.GetById(Id);
            return Ok(crop);
        }

        [HttpGet("cropsByfarmId/{Id}")]
        public OkObjectResult GetByFarmId(int Id)
        {
            var crops = _cropService.GetByFarmId(Id);
            return Ok(crops);
        }

        [HttpPost("crop")]
        public CreatedResult Add([FromBody] Crop crop)
        {
            _cropService.Add(crop);
            return Created();
        }

        [HttpPut("cropUpdate")]
        public OkResult Update([FromBody] Crop crop)
        {
            _cropService.Update(crop);
            return Ok();
        }

        [HttpDelete("crop/{id}")]
        public OkResult Delete(int id)
        {
            _cropService.Delete(id);
            return Ok();
        }
    }
}
