using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Domain.Interfaces;
using FarmManagementSystem.Infra.Data;

namespace FarmManagementSystem.Infra.Repositorios
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly AppDbContext _appDbContext;
        public AnimalRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public ICollection<Animal> GetAll()
        {
            return _appDbContext.Animal.ToList();
        }

        public Animal GetById(int Id)
        {
            return _appDbContext.Animal.FirstOrDefault(x => x.Id == Id);
        }

        public ICollection<Animal> GetByFarmId(int farmId)
        {
            return _appDbContext.Animal.Where(x => x.FarmId == farmId).ToList();
        }

        public void Add(Animal animal)
        {
            _appDbContext.Add(animal);
            _appDbContext.SaveChanges();
        }
        public void Update(Animal animal)
        {
            _appDbContext.Update(animal);
            _appDbContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            _appDbContext.Remove(Id);
            _appDbContext.SaveChanges();
        }
    }
}
