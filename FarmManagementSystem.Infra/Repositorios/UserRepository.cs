using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Domain.Interfaces;
using FarmManagementSystem.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace FarmManagementSystem.Infra.Repositorios
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public ICollection<User> GetAll()
        {
            return _appDbContext.User
                .AsNoTracking()
                .ToList();
        }

        public User GetById(int Id)
        {
            return _appDbContext
                .User
                .AsNoTracking()
                .First(x => x.Id == Id);
        }

        public void Add(User user)
        {
            _appDbContext.Add(user);
            _appDbContext.SaveChanges();
        }

        public void Update(User userInDb, User user)
        {
            _appDbContext
                .Attach(userInDb)
                .CurrentValues
                .SetValues(user);

            _appDbContext.SaveChanges();
        }

        public void Delete(User user)
        {
            _appDbContext.Remove(user);
            _appDbContext.SaveChanges();
        }
    }
}
