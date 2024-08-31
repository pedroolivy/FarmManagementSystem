using FarmManagementSystem.Domain.Entities;

namespace FarmManagementSystem.Domain.Interfaces
{
    public interface IAnimalRepository
    {
        List<Animal> GetAll();
        Animal GetById(int id);
        Animal GetByFarmId(int farmId);
        void Add(Animal animal);
        void Update(Animal animalInDb, Animal animal);
        void Delete(Animal animal);
    }
}
