using FarmManagementSystem.Domain.Enums;

namespace FarmManagementSystem.Domain.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public AnimalType Type { get; set; }
        public int FarmId { get; set; }
    }
}
