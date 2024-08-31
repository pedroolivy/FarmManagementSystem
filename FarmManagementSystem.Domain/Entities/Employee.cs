using FarmManagementSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FarmManagementSystem.Domain.Entities
{
    public class Employee
    {
        private const int Empty = 0;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }
        public int FarmId { get; set; }

        public void Validate()
        {
            if (FarmId == Empty || FarmId == null)
                throw new ValidationException("O Id da fazenda deve ser informado.");

            if (string.IsNullOrWhiteSpace(Name))
                throw new ValidationException("O nome do colaborador é obrigatório.");

            if (Salary < Empty)
                throw new ValidationException("O salário deve ser maior que zero.");
        }

        public void ValidateId()
        {
            if (Id <= Empty)
                throw new ValidationException("Id do colaborador não encontrado!");
        }
    }
}