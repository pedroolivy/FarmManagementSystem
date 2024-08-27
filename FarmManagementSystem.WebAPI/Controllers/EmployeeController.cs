using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace FarmManagementSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("employees")]
        public OkObjectResult GetAll()
        {
            var employees = _employeeService.GetAll();
            return Ok(employees);
        }

        [HttpGet("employee/{Id}")]
        public OkObjectResult GetById(int Id)
        {
            var employee = _employeeService.GetById(Id);
            return Ok(employee);
        }

        [HttpGet("employeesByfarmId/{Id}")]
        public OkObjectResult GetByFarmId(int Id)
        {
            var employees = _employeeService.GetByFarmId(Id);
            return Ok(employees);
        }

        [HttpPost("employee")]
        public CreatedResult Add([FromBody] Employee employee)
        {
            _employeeService.Add(employee);
            return Created();
        }

        [HttpPut("employeeUpdate")]
        public OkResult Update([FromBody] Employee employee)
        {
            _employeeService.Update(employee);
            return Ok();
        }

        [HttpDelete("employee/{id}")]
        public OkResult Delete(int id)
        {
            _employeeService.Delete(id);
            return Ok();
        }
    }
}
