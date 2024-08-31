using FarmManagementSystem.Domain.Entities;

namespace FarmManagementSystem.Domain.Interfaces.IRepositories
{
    public interface ICropRepository
    {
        List<Crop> GetAll();
        Crop GetById(int Id);
        List<Crop> GetByFarmId(int farmId);
        void Add(Crop crop);
        void Update(Crop cropInDb, Crop crop);
        void Delete(Crop crop);
    }
}
