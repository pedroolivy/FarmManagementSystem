using FarmManagementSystem.Domain.Enums;
using FarmManagementSystem.Domain.Interfaces;

namespace FarmManagementSystem.Domain.Entities
{
    public class Crop : IEntity
    {
        public int Id { get; set; }
        public int FarmId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Area { get; set; }
        public CropStatus CropStatus { get; set; }
    }
}