using FarmManagementSystem.Domain.Entities;

namespace FarmManagementSystem.Domain.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int Id);
        void Add(User user);
        void Update(User userInDb, User user);
        void Delete(User user);
    }
}
