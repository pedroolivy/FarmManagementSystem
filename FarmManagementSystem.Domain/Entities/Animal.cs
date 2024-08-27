using FarmManagementSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FarmManagementSystem.Domain.Entities
{
    public class Animal
    {
        private const int Empty = 0;

        public int Id { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public AnimalType Type { get; set; }
        public int FarmId { get; set; }

        public void Validate()
        {

            if (string.IsNullOrWhiteSpace(Species))
                throw new ValidationException("A espécie do animal é obrigatória.");

            if (Age < Empty)
                throw new ValidationException("A idade do animal deve ser positiva.");
        }
    }
}