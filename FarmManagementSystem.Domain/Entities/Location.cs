namespace FarmManagementSystem.Domain.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public int FarmId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Location(double latitude, double longitude) 
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}