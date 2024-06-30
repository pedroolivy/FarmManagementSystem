using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace FarmManagementSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("users")]
        public OkObjectResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("user/{Id}")]
        public OkObjectResult GetById([FromRoute]int Id)
        {
            var user = _userService.GetById(Id);
            return Ok(user);
        }

        [HttpPost("user")]
        public CreatedResult Add([FromBody] User user)
        {
            _userService.Add(user);
            return Created();
        }

        [HttpPatch("userUpdate/{id}")]
        public OkResult Update([FromRoute] int id, User user)
        {
            _userService.Update(id, user);
            return Ok();
        }

        [HttpDelete("usuario/{id}")]
        public OkResult Delete([FromRoute] int id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}
