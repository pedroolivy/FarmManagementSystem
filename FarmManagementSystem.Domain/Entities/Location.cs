using System.ComponentModel.DataAnnotations;

namespace FarmManagementSystem.Domain.Entities
{
    public class Location
    {
        private const int Empty = 0;
        private const double MinLatitude = -90.0;
        private const double MaxLatitude = 90.0;
        private const double MinLongitude = -180.0;
        private const double MaxLongitude = 180.0;
        
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int FarmId { get; set; }

        public void Validate()
        {

            if (Latitude < MinLatitude || Latitude > MaxLatitude)
                throw new ValidationException($"A latitude deve estar entre {MinLatitude} e {MaxLatitude} graus.");

            if (Longitude < MinLongitude || Longitude > MaxLongitude)
                throw new ValidationException($"A longitude deve estar entre {MinLongitude} e {MaxLongitude} graus.");
        }

        public void ValideFarmId()
        {
            if (FarmId <= Empty)
                throw new ValidationException("Um FarmId válido deve estar associado à localização.");
        }
    }
}