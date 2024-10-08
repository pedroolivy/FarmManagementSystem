﻿using FarmManagementSystem.Services.Dtos;
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
        public OkObjectResult GetById(int Id)
        {
            var user = _userService.GetById(Id);
            return Ok(user);
        }

        [HttpPost("user")]
        public CreatedResult Add([FromBody] UserDto userDto)
        {
            _userService.Add(userDto);
            return Created();
        }

        [HttpPut("userUpdate")]
        public OkResult Update([FromBody] UserDto userDto)
        {
            _userService.Update(userDto);
            return Ok();
        }

        [HttpDelete("usuario/{id}")]
        public OkResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}
