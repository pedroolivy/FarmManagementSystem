using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Domain.Interfaces;
using FarmManagementSystem.Infra.Data;

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
            return _appDbContext.User.ToList();
        }

        public User GetById(int Id)
        {
            return _appDbContext.User.FirstOrDefault(x => x.Id == Id);
        }

        public void Add(User user)
        {
            _appDbContext.Add(user);
            _appDbContext.SaveChanges();
        }

        public void Update(User user)
        {
            _appDbContext.Update(user);
            _appDbContext.SaveChanges();
        }

        public void Delete(int user)
        {
            _appDbContext.Remove(user);
            _appDbContext.SaveChanges();
        }
    }
}
