using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Domain.Interfaces;
using FarmManagementSystem.Services.Dtos;
using System.ComponentModel.DataAnnotations;

namespace FarmManagementSystem.Services.Services
{
    public class FarmService(IFarmRepository farmRepository, ILocationRepository locationRepository)
    {
        private readonly IFarmRepository _farmRepository = farmRepository;
        private readonly ILocationRepository _locationRepository = locationRepository;

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
                var farm = _farmRepository.GetById(Id);

                if (farm == null)
                    throw new ValidationException("Não existem registros dessa fazenda em nosso sistemma.");

                return farm;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Farm> GetByUserId(int userId)
        {
            try
            {
                return _farmRepository.GetByUserId(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Add(FarmDto FarmDto)
        {
            try
            {
                var farm = ProcessingAddfields(FarmDto);

                _farmRepository.Add(farm);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(FarmDto FarmDto)
        {
            try
            {
                var farm = ProcessingUpdatefields(FarmDto);
                var farmInDb = _farmRepository.GetById(farm.Id);

                if (farmInDb == null)
                    throw new ValidationException("Não existem registros dessa fazenda em nosso sistemma.");

                if (!farmInDb.IsFarmActive())
                    throw new ValidationException("Apenas fazendas ativas podem sofrar modificações.");

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
                var farmLocationInDb = _locationRepository.GetById(farmInDb.Id);

                if (farmInDb == null && farmLocationInDb == null)
                    throw new ValidationException("Não existem registros dessa fazenda em nosso sistemma.");

                if (farmInDb.IsFarmActive())
                    throw new ValidationException("Apenas fazenda desativadas podem ser excluidas.");

                farmInDb.Location = farmLocationInDb;
                _farmRepository.Delete(farmInDb);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #region processingFields
        private static Farm ProcessingAddfields(FarmDto farmDto)
        {
            var farm = new Farm
            {
                UserId = farmDto.UserId,
                Name = farmDto.Name,
                Description = farmDto.Description,
                DateAdd = farmDto.DateAdd,
                FarmIsActive = farmDto.FarmIsActive,
                Location = new Location
                {
                    Latitude = farmDto.Location.Latitude,
                    Longitude = farmDto.Location.Longitude,
                }
            };

            farm.Validate();
            farm.Location.Validate();

            return farm;
        }

        private static Farm ProcessingUpdatefields(FarmDto farmDto)
        {
            var farm = new Farm
            {
                Id = farmDto.Id,
                UserId = farmDto.UserId,
                Name = farmDto.Name,
                Description = farmDto.Description,
                DateAdd = farmDto.DateAdd,
                FarmIsActive = farmDto.FarmIsActive,
            };

            farm.ValidateId();
            farm.Validate();

            return farm;
        }
        #endregion

    }
}
