using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Domain.Interfaces;

namespace FarmManagementSystem.Services.Services
{
    public class LocationService
    {
        private readonly ILocationRepository _locationRepository;
        public LocationService(ILocationRepository locationRepository) 
        {
            _locationRepository = locationRepository;
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
                return _locationRepository.GetById(Id);
            }
            catch (Exception)
            {
                throw new Exception("Localização não encontrada");
            }
        }

        public void Add(Location location)
        {

            try
            {
                _locationRepository.Add(location);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Update(Location location)
        {
            try
            {
                var locationInDb = _locationRepository.GetById(location.Id);
                _locationRepository.Update(locationInDb, location);
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
                var locationInDb = _locationRepository.GetById(id);
                _locationRepository.Delete(locationInDb);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
