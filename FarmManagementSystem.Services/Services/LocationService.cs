﻿using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Domain.Interfaces;
using FarmManagementSystem.Services.Dtos;
using System.ComponentModel.DataAnnotations;

namespace FarmManagementSystem.Services.Services
{
    public class LocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IFarmRepository _farmRepository;
        public LocationService(ILocationRepository locationRepository, IFarmRepository farmRepository) 
        {
            _locationRepository = locationRepository;
            _farmRepository = farmRepository;
        }

        public List<Location> GetAll()
        {
            try
            {
                return _locationRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Location GetById(int Id)
        {
            try
            {
                var location = _locationRepository.GetById(Id);

                if (location == null)
                    throw new ValidationException("Localização não encontrada.");

                return location;
            }
            catch (Exception)
            {
                throw new Exception("Localização não encontrada");
            }
        }

        public Location GetByFarmId(int faramId)
        {
            try
            {
                var location = _locationRepository.GetByFarmId(faramId);

                if (location == null)
                    throw new ValidationException("Localização não encontrada.");

                return location;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(LocationDto locationDto)
        {
            try
            {
                var location = ProcessingUpdatefields(locationDto);
                var locationInDb = _locationRepository.GetById(location.Id);

                if (locationInDb == null)
                    throw new ValidationException("Localização não encontrada.");

                location.FarmId = locationInDb.FarmId;
                location.ValideFarmId();

                var farm = _farmRepository.GetById(location.FarmId);

                if (!farm.IsFarmActive())
                    throw new ValidationException("A fazenda com essa localização está inativa");

                _locationRepository.Update(locationInDb, location);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
         
        #region processingFields
        private static Location ProcessingUpdatefields(LocationDto locationDto)
        {
            var location = new Location
            {
                Id = locationDto.Id,
                Latitude = locationDto.Latitude,
                Longitude = locationDto.Longitude
            };

            location.Validate();
            
            return location;
        }
        #endregion
    }
}
