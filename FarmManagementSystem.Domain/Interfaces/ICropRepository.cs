using FarmManagementSystem.Domain.Entities;

namespace FarmManagementSystem.Domain.Interfaces
{
    public interface ICropRepository
    {
        ICollection<Crop> GetAll();
        Crop GetById(int Id);
        ICollection<Crop> GetByFarmId(int farmId);
        void Add(Crop crop);
        void Update(Crop crop);
        void Delete(int Id);
    }
}
