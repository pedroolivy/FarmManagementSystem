using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Domain.Interfaces;
using FarmManagementSystem.Infra.Data;

namespace FarmManagementSystem.Infra.Repositorios
{
    public class FarmRepository : IFarmRepository
    {
        private readonly AppDbContext _appDbContext;
        public FarmRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public ICollection<Farm> GetAll()
        {
            return _appDbContext.Farm.ToList();
        }

        public Farm GetById(int Id)
        {
            return _appDbContext.Farm.FirstOrDefault(x => x.Id == Id);
        }

        public ICollection<Farm> GetByUserId(int userId)
        {
            return _appDbContext.Farm.Where(x => x.UserId == userId).ToList();
        }

        public void Add(Farm farm)
        {
            _appDbContext.Add(farm);
            _appDbContext.SaveChanges();
        }
        public void Update(Farm farm)
        {
            _appDbContext.Update(farm);
            _appDbContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            _appDbContext.Remove(Id);
            _appDbContext.SaveChanges();
        }
    }
}
