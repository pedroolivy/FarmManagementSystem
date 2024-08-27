using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace FarmManagementSystem.WebAPI.Controllers
{
    public class AnimalController : ControllerBase
    {
        private readonly AnimalService _animalService;

        public AnimalController(AnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet("animals")]
        public OkObjectResult GetAll()
        {
            var animals = _animalService.GetAll();
            return Ok(animals);
        }

        [HttpGet("animal/{Id}")]
        public OkObjectResult GetById(int Id)
        {
            var animal = _animalService.GetById(Id);
            return Ok(animal);
        }

        [HttpGet("animalsByfarmId/{Id}")]
        public OkObjectResult GetByFarmId(int Id)
        {
            var animals = _animalService.GetByFarmId(Id);
            return Ok(animals);
        }

        [HttpPost("animal")]
        public CreatedResult Add([FromBody] Animal animal)
        {
            _animalService.Add(animal);
            return Created();
        }

        [HttpPut("animalUpdate")]
        public OkResult Update([FromBody] Animal animal)
        {
            _animalService.Update(animal);
            return Ok();
        }

        [HttpDelete("animal/{id}")]
        public OkResult Delete(int id)
        {
            _animalService.Delete(id);
            return Ok();
        }
    }
}
