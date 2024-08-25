using FarmManagementSystem.Domain.Entities;

namespace FarmManagementSystem.Domain.Interfaces
{
    public interface ILocationRepository
    {
        List<Location> GetAll();
        Location GetById(int Id);
        List<Location> GetByFarmId(int farmId);
        void Add(Location location);
        void Update(Location locationInDb, Location location);
        void Delete(Location location);
    }
}
