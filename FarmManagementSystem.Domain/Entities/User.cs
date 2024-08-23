using System.Text.Json.Serialization;

namespace FarmManagementSystem.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string Position { get; set; }
        [JsonIgnore]
        public List<Farm>? Farms { get; set; }
    }
}