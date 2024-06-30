using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Domain.Interfaces;
using FarmManagementSystem.Infra.Data;

namespace FarmManagementSystem.Infra.Repositorios
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext _appDbContext;
        public LocationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public ICollection<Location> GetAll()
        {
            return _appDbContext.Location.ToList();
        }

        public Location GetById(int Id)
        {
            return _appDbContext.Location.FirstOrDefault(x => x.Id == Id);
        }

        public ICollection<Location> GetByFarmId(int farmId)
        {
            return _appDbContext.Location.Where(x => x.FarmId == farmId).ToList();
        }

        public void Add(Location location)
        {
            _appDbContext.Add(location);
            _appDbContext.SaveChanges();
        }
        public void Update(Location location)
        {
            _appDbContext.Update(location);
            _appDbContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            _appDbContext.Remove(Id);
            _appDbContext.SaveChanges();
        }
    }
}
