using FarmManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FarmManagementSystem.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Farm> Farm { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Crop> Crop { get; set; }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<Employee> Employee { get; set; }
    }
}
