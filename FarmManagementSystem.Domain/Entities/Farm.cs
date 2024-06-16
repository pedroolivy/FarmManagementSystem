using FarmManagementSystem.Domain.Interfaces;

namespace FarmManagementSystem.Domain.Entities
{
    public class Farm : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public List<Crop>? Crops { get; set; }
        public List<Animal>? Animals { get; set; }
        public List<Employee>? Employees { get; set; }
    }
}