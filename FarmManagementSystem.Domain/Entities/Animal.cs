using FarmManagementSystem.Domain.Enums;
using FarmManagementSystem.Domain.Interfaces;

namespace FarmManagementSystem.Domain.Entities
{
    public class Animal : IEntity
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public AnimalType Type { get; set; }
        public int FarmId { get; set; }
        public required Farm Farm { get; set; }
    }
}
