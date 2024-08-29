using FarmManagementSystem.Domain.Entities;

namespace FarmManagementSystem.Services.Dtos
{
    public class FarmDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateAdd { get; set; }
        public bool FarmIsActive { get; set; }
        public LocationDto? Location { get; set; }
    }
}
