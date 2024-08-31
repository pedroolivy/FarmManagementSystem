using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Domain.Interfaces.IRepositories;
using FarmManagementSystem.Infra.Data;

namespace FarmManagementSystem.Infra.Repositorios
{
    public class EmployeeRpository : IEmployeeRpository
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeRpository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<Employee> GetAll()
        {
            return _appDbContext.Employee.ToList();
        }

        public Employee GetById(int Id)
        {
            return _appDbContext.Employee.FirstOrDefault(x => x.Id == Id);
        }

        public List<Employee> GetByFarmId(int farmId)
        {
            return _appDbContext.Employee.Where(x => x.FarmId == farmId).ToList();
        }

        public void Add(Employee employee)
        {
            _appDbContext.Add(employee);
            _appDbContext.SaveChanges();
        }
        public void Update(Employee employeeInDb, Employee employee)
        {
            _appDbContext
                .Attach(employeeInDb)
                .CurrentValues
                .SetValues(employee);

            _appDbContext.SaveChanges();
        }

        public void Delete(Employee employeeInDb)
        {
            _appDbContext.Remove(employeeInDb);
            _appDbContext.SaveChanges();
        }
    }
}
