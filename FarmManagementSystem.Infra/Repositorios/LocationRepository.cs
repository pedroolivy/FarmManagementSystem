using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Domain.Interfaces.IRepositories;
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
        public List<Location> GetAll()
        {
            return _appDbContext.Location.ToList();
        }

        public Location GetById(int Id)
        {
            return _appDbContext.Location.FirstOrDefault(x => x.Id == Id);
        }

        public Location GetByFarmId(int farmId)
        {
            return _appDbContext.Location.FirstOrDefault(x => x.FarmId == farmId);
        }

        public void Update(Location locationInDb, Location location)
        {
            _appDbContext
                .Attach(locationInDb)
                .CurrentValues
                .SetValues(location);

            _appDbContext.SaveChanges();
        }
    }
}
