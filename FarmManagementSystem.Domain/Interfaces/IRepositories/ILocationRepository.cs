using FarmManagementSystem.Domain.Entities;

namespace FarmManagementSystem.Domain.Interfaces.IRepositories
{
    public interface ILocationRepository
    {
        List<Location> GetAll();
        Location GetById(int Id);
        Location GetByFarmId(int farmId);
        void Update(Location locationInDb, Location location);
    }
}
