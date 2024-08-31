using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Domain.Interfaces.IRepositories;

namespace FarmManagementSystem.Services.Services
{
    public class AnimalService(IAnimalRepository animalRepository)
    {
        private readonly IAnimalRepository _animalRepository = animalRepository;

        public List<Animal> GetAll()
        {
            try
            {
                return _animalRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Animal GetById(int Id)
        {
            try
            {
                return _animalRepository.GetById(Id);
            }
            catch (Exception)
            {
                throw new Exception("Animal não encontrado");
            }
        }

        public List<Animal> GetByFarmId(int farmId)
        {
            try
            {
                return _animalRepository.GetByFarmId(farmId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Add(Animal animal)
        {
            try
            {
                _animalRepository.Add(animal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Animal animal)
        {
            try
            {
                var animalInDb = _animalRepository.GetById(animal.Id);
                _animalRepository.Update(animalInDb, animal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var animalInDb = _animalRepository.GetById(id);
                _animalRepository.Delete(animalInDb);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
