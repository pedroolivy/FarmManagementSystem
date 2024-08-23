using FarmManagementSystem.Domain.Enums;

namespace FarmManagementSystem.Domain.Entities
{
    public class Crop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Area { get; set; }
        public CropStatus CropStatus { get; set; }
        public int FarmId { get; set; }
    }
}