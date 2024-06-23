namespace FarmManagementSystem.Domain.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int FarmId { get; set; }
        public required Farm Farm { get; set; }
    }
}