using FarmManagementSystem.Domain.Entities;

namespace FarmManagementSystem.Domain.Interfaces
{
    public interface ILocationRepository
    {
        ICollection<Location> GetAll();
        Location GetById(int Id);
        ICollection<Location> GetByFarmId(int farmId);
        void Add(Location location);
        void Update(Location location);
        void Delete(int Id);
    }
}
