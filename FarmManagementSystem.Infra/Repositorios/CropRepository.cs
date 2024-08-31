using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Domain.Interfaces;
using FarmManagementSystem.Infra.Data;

namespace FarmManagementSystem.Infra.Repositorios
{
    public class CropRepository : ICropRepository
    {
        private readonly AppDbContext _appDbContext;

        public CropRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Crop> GetAll()
        {
            return _appDbContext.Crop.ToList();
        }

        public Crop GetById(int Id)
        {
            return _appDbContext.Crop.FirstOrDefault(x => x.Id == Id);
        }

        public List<Crop> GetByFarmId(int farmId)
        {
            return _appDbContext.Crop.Where(x => x.FarmId == farmId).ToList();
        }

        public void Add(Crop crop)
        {
            _appDbContext.Add(crop);
            _appDbContext.SaveChanges();
        }
        public void Update(Crop cropInDb, Crop crop)
        {
            _appDbContext
                .Attach(cropInDb)
                .CurrentValues
                .SetValues(crop);

            _appDbContext.SaveChanges();
        }

        public void Delete(Crop crop)
        {
            _appDbContext.Remove(crop);
            _appDbContext.SaveChanges();
        }

    }
}
