using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Domain.Interfaces.IRepositories;
using System.ComponentModel.DataAnnotations;

namespace FarmManagementSystem.Services.Services
{
    public class EmployeeService(IEmployeeRpository employeeRpository, IFarmRepository farmRepository)
    {
        private readonly IEmployeeRpository _employeeRpository = employeeRpository;
        private readonly IFarmRepository _farmRepository = farmRepository;

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
                var employee = _employeeRpository.GetById(Id);

                if (employee == null)
                    throw new ValidationException("Não existem registros desse colaborador em nosso sistemma.");

                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                Employee.Validate();
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

                if (employeeInDb == null)
                    throw new ValidationException("Não existem registros desse colaborador em nosso sistemma.");

                var farm = _farmRepository.GetById(employeeInDb.FarmId);

                if(!farm.IsFarmActive())
                    throw new ValidationException("A fazenda desse colaborador está inativa");

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

                if (employeeInDb == null)
                    throw new ValidationException("Colaborador não encontrado.");

                var farm = _farmRepository.GetById(employeeInDb.FarmId);

                if (!farm.IsFarmActive())
                    throw new ValidationException("A fazenda desse colaborador está inativa");

                _employeeRpository.Delete(employeeInDb);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
