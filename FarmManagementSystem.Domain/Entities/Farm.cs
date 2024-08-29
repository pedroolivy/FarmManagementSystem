using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FarmManagementSystem.Domain.Entities
{
    public class Farm
    {
        private const int Empty = 0;

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateAdd { get; set; }
        public bool FarmIsActive { get; set; }
        public Location? Location { get; set; }
        public List<Crop>? Crops { get; set; }
        public List<Animal>? Animals { get; set; }
        public List<Employee>? Employees { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ValidationException("O nome da fazenda é obrigatório.");

            if (UserId < Empty)
                throw new ValidationException("Um usuário válido deve estar associado à fazenda.");

            if (DateAdd <= DateTime.Now)
                throw new ValidationException("A data não pode ser menor que a data atual.");
        }

        public void ValidateId()
        {
            if (Id <= Empty) 
                throw new ValidationException("Id da Fazenda não encontrado!");
        }
        public bool IsFarmActive() => FarmIsActive;

    }
}   