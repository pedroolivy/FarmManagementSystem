using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Domain.Interfaces;

namespace FarmManagementSystem.Services.Services
{
    public class FarmService(IFarmRepository farmRepository)
    {
        private readonly IFarmRepository _farmRepository = farmRepository;

        public List<Farm> GetAll()
        {
            try
            {
                return _farmRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Farm GetById(int Id)
        {
            try
            {
                return _farmRepository.GetById(Id);
            }
            catch (Exception)
            {
                throw new Exception("Fazenda não encontrada");
            }
        }

        public void Add(Farm user)
        {

            try
            {
                _farmRepository.Add(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Update(Farm farm)
        {
            try
            {
                var farmInDb = _farmRepository.GetById(farm.Id);
                _farmRepository.Update(farmInDb, farm);
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
                var farmInDb = _farmRepository.GetById(id);
                _farmRepository.Delete(farmInDb);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
