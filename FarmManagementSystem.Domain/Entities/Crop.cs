using FarmManagementSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FarmManagementSystem.Domain.Entities
{
    public class Crop
    {
        private const int Empty = 0;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Area { get; set; }
        public DateTime DateAdd { get; set; }
        public CropStatus CropStatus { get; set; }
        public int FarmId { get; set; }

        public void Validate()
        {
            if (FarmId == Empty || FarmId == null)
                throw new ValidationException("O Id da fazenda deve ser informado.");

            if (string.IsNullOrWhiteSpace(Name))
                throw new ValidationException("O nome da cultura é obrigatório.");

            if (Area < Empty)
                throw new ValidationException("A área deve ser maior que zero.");

            if (DateAdd <= DateTime.Now)
                throw new ValidationException("A data não pode ser menor que a data atual.");
        }

        public void ValidateId()
        {
            if (Id <= Empty)
                throw new ValidationException("Id da cultura não encontrado!");
        }
    }
}