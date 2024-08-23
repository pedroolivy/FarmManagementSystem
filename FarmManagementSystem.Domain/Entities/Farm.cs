using System.Text.Json.Serialization;

namespace FarmManagementSystem.Domain.Entities
{
    public class Farm
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public Location? Location { get; set; }
        [JsonIgnore]
        public List<Crop>? Crops { get; set; }
        [JsonIgnore]
        public List<Animal>? Animals { get; set; }
        [JsonIgnore]
        public List<Employee>? Employees { get; set; }
    }
}   