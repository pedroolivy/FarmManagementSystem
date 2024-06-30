using FarmManagementSystem.Domain.Entities;

namespace FarmManagementSystem.Domain.Interfaces
{
    public interface IEmployeeRpository
    {
        ICollection<Employee> GetAll();
        Employee GetById(int Id);
        ICollection<Employee> GetByFarmId(int farmId);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(int Id);
    }
}
