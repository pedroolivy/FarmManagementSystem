using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FarmManagementSystem.Services.Services
{
    public class AnimalService(IAnimalRepository animalRepository, IFarmRepository farmRepository)
    {
        private readonly IAnimalRepository _animalRepository = animalRepository;
        private readonly IFarmRepository _farmRepository = farmRepository;

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
                var animal = _animalRepository.GetById(Id);

                if (animal == null)
                    throw new ValidationException("Não existem registros desse animal em nosso sistemma.");

                return animal;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Animal GetByFarmId(int farmId)
        {
            try
            {
                var animal = _animalRepository.GetByFarmId(farmId);

                if (animal == null)
                    throw new ValidationException("Não existem registros desse animal em nosso sistemma.");

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
                animal.Validate();
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
                animal.Validate();
                animal.ValidateId();

                var animalInDb = _animalRepository.GetById(animal.Id);

                if (animalInDb == null)
                    throw new ValidationException("Não existem registros desse animal em nosso sistemma.");

                var farm = _farmRepository.GetById(animalInDb.FarmId);

                if (!farm.IsFarmActive())
                    throw new ValidationException("A fazenda que contem esse animal está inativa.");

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

                if (animalInDb == null)
                    throw new ValidationException("Não existem registros desse animal em nosso sistemma.");

                var farm = _farmRepository.GetById(animalInDb.FarmId);

                if (!farm.IsFarmActive())
                    throw new ValidationException("A fazenda que contem esse animal está inativa.");

                _animalRepository.Delete(animalInDb);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
