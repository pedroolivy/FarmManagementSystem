using System.ComponentModel.DataAnnotations;

namespace FarmManagementSystem.Domain.Entities
{
    public class Farm
    {
        private const int Empty = 0;

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
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
        }
    }
}   