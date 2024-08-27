using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Domain.Interfaces;

namespace FarmManagementSystem.Services.Services
{
    public class CropService(ICropRepository cropRepository)
    {
        private readonly ICropRepository _cropRepository = cropRepository;

        public List<Crop> GetAll()
        {
            try
            {
                return _cropRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Crop GetById(int Id)
        {
            try
            {
                return _cropRepository.GetById(Id);
            }
            catch (Exception)
            {
                throw new Exception("Cultura não encontrada");
            }
        }

        public List<Crop> GetByFarmId(int farmId)
        {
            try
            {
                return _cropRepository.GetByFarmId(farmId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Add(Crop crop)
        {
            try
            {
                _cropRepository.Add(crop);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Crop crop)
        {
            try
            {
                var cropInDb = _cropRepository.GetById(crop.Id);
                _cropRepository.Update(cropInDb, crop);
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
                var cropInDb = _cropRepository.GetById(id);
                _cropRepository.Delete(cropInDb);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
