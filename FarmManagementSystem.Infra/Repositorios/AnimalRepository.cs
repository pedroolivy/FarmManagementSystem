﻿using FarmManagementSystem.Domain.Entities;
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
        public List<Animal> GetAll()
        {
            return _appDbContext.Animal.ToList();
        }

        public Animal GetById(int Id)
        {
            return _appDbContext.Animal.FirstOrDefault(x => x.Id == Id);
        }

        public Animal GetByFarmId(int farmId)
        {
            return _appDbContext.Animal.FirstOrDefault(x => x.FarmId == farmId);
        }

        public void Add(Animal animal)
        {
            _appDbContext.Add(animal);
            _appDbContext.SaveChanges();
        }
        public void Update(Animal animalInDb, Animal animal)
        {
            _appDbContext
                .Attach(animalInDb)
                .CurrentValues
                .SetValues(animal);

            _appDbContext.SaveChanges();
        }

        public void Delete(Animal animal)
        {
            _appDbContext.Remove(animal);
            _appDbContext.SaveChanges();
        }
    }
}
