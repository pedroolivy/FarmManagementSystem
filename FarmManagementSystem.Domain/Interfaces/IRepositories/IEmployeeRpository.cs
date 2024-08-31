using FarmManagementSystem.Domain.Entities;

namespace FarmManagementSystem.Domain.Interfaces.IRepositories
{
    public interface IEmployeeRpository
    {
        List<Employee> GetAll();
        Employee GetById(int Id);
        List<Employee> GetByFarmId(int farmId);
        void Add(Employee employee);
        void Update(Employee employeeInDb, Employee employee);
        void Delete(Employee employeeInDb);
    }
}
