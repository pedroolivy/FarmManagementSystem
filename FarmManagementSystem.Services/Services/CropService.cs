using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FarmManagementSystem.Services.Services
{
    public class CropService(ICropRepository cropRepository, IFarmRepository farmRepository)
    {
        private readonly ICropRepository _cropRepository = cropRepository;
        private readonly IFarmRepository _farmRepository = farmRepository;

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
                var crop = _cropRepository.GetById(Id);

                if(crop == null)
                    throw new ValidationException("Não existem registros dessa cultura em nosso sistemma.");

                return crop;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                crop.Validate();
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
                crop.Validate();
                crop.ValidateId();

                var cropInDb = _cropRepository.GetById(crop.Id);

                if (cropInDb == null)
                    throw new ValidationException("Não existem registros dessa cultura em nosso sistemma.");

                var farm = _farmRepository.GetById(cropInDb.FarmId);

                if (!farm.IsFarmActive())
                    throw new ValidationException("A fazenda que contem essa cultura está inativa.");

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

                if (cropInDb == null)
                    throw new ValidationException("Não existem registros dessa cultura em nosso sistemma.");

                var farm = _farmRepository.GetById(cropInDb.FarmId);

                if (!farm.IsFarmActive())
                    throw new ValidationException("A fazenda que contem essa cultura está inativa.");

                _cropRepository.Delete(cropInDb);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
