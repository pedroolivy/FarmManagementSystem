using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Domain.Interfaces;
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
        public ICollection<Employee> GetAll()
        {
            return _appDbContext.Employee.ToList();
        }

        public Employee GetById(int Id)
        {
            return _appDbContext.Employee.FirstOrDefault(x => x.Id == Id);
        }

        public ICollection<Employee> GetByFarmId(int farmId)
        {
            return _appDbContext.Employee.Where(x => x.FarmId == farmId).ToList();
        }

        public void Add(Employee employee)
        {
            _appDbContext.Add(employee);
            _appDbContext.SaveChanges();
        }
        public void Update(Employee employee)
        {
            _appDbContext.Update(employee);
            _appDbContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            _appDbContext.Remove(Id);
            _appDbContext.SaveChanges();
        }
    }
}
