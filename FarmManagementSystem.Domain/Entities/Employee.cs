using FarmManagementSystem.Domain.Enums;
using FarmManagementSystem.Domain.Interfaces;

namespace FarmManagementSystem.Domain.Entities
{
    public class Employee : IEntity
    {
        public int Id { get; set; }
        public int FarmId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }
    }
}