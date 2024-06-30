using FarmManagementSystem.Domain.Entities;

namespace FarmManagementSystem.Domain.Interfaces
{
    public interface IAnimalRepository
    {
        ICollection<Animal> GetAll();
        Animal GetById(int id);
        ICollection<Animal> GetByFarmId(int farmId);
        void Add(Animal animal);
        void Update(Animal animal);
        void Delete(int Id);
    }
}
