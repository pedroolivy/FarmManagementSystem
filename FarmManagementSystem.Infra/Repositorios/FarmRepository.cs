using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Domain.Interfaces;
using FarmManagementSystem.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace FarmManagementSystem.Infra.Repositorios
{
    public class FarmRepository : IFarmRepository
    {
        private readonly AppDbContext _appDbContext;
        public FarmRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<Farm> GetAll()
        {
            return _appDbContext.Farm
                .AsNoTracking()
                .ToList();
        }

        public Farm GetById(int Id)
        {
            return _appDbContext
                .Farm
                .AsNoTracking()
                .First(x => x.Id == Id);
        }

        public List<Farm> GetByUserId(int userId)
        {
            return _appDbContext.Farm
                .Where(x => x.UserId == userId)
                .ToList();
        }

        public void Add(Farm farm)
        {
            _appDbContext.Add(farm);
            _appDbContext.SaveChanges();
        }

        public void Update(Farm farmInDb, Farm farm)
        {
            _appDbContext
                .Attach(farmInDb)
                .CurrentValues
                .SetValues(farm);

            _appDbContext.SaveChanges();
        }

        public void Delete(Farm farm)
        {
            _appDbContext.Remove(farm);
            _appDbContext.SaveChanges();
        }
    }
}
