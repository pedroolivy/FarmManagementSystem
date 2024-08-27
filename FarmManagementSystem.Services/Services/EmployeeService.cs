using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Domain.Interfaces;

namespace FarmManagementSystem.Services.Services
{
    public class EmployeeService(IEmployeeRpository employeeRpository)
    {
        private readonly IEmployeeRpository _employeeRpository = employeeRpository;

        public List<Employee> GetAll()
        {
            try
            {
                return _employeeRpository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Employee GetById(int Id)
        {
            try
            {
                return _employeeRpository.GetById(Id);
            }
            catch (Exception)
            {
                throw new Exception("Funcionário não encontrado");
            }
        }

        public List<Employee> GetByFarmId(int farmId)
        {
            try 
            {
                return _employeeRpository.GetByFarmId(farmId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Add(Employee Employee)
        {
            try
            {
                _employeeRpository.Add(Employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Employee employee)
        {
            try
            {
                var employeeInDb = _employeeRpository.GetById(employee.Id);
                _employeeRpository.Update(employeeInDb, employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var employeeInDb = _employeeRpository.GetById(id);
                _employeeRpository.Delete(employeeInDb);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
