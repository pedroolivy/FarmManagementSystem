using FarmManagementSystem.Domain.Enums;

namespace FarmManagementSystem.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }
        public int FarmId { get; set; }
    }
}