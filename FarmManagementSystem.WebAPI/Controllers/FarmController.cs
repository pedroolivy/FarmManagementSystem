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

        [HttpGet("users")]
        public OkObjectResult GetAll()
        {
            var users = _farmService.GetAll();
            return Ok(users);
        }

        [HttpGet("user/{Id}")]
        public OkObjectResult GetById(int Id)
        {
            var user = _farmService.GetById(Id);
            return Ok(user);
        }

        [HttpPost("user")]
        public CreatedResult Add([FromBody] Farm farm)
        {
            _farmService.Add(farm);
            return Created();
        }

        [HttpPut("userUpdate")]
        public OkResult Update([FromBody] Farm farm)
        {
            _farmService.Update(farm);
            return Ok();
        }

        [HttpDelete("usuario/{id}")]
        public OkResult Delete(int id)
        {
            _farmService.Delete(id);
            return Ok();
        }
    }
}
