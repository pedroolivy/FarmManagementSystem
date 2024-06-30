using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Domain.Interfaces;

namespace FarmManagementSystem.Services.Services
{
    public class UserService(IUserRepository userRepository)
    {
        private readonly IUserRepository _userRepository = userRepository;

        public ICollection<User> GetAll()
        {
            try
            {
                return _userRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public User GetById(int Id)
        {
            try
            {
                return _userRepository.GetById(Id);
            }
            catch (Exception)
            {
                throw new Exception("Usuário não encontrado");
            }
        }

        public void Add(User user)
        {

            try
            {
                _userRepository.Add(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public void Update(int id, User user)
        {
            try
            {
                var userInDb = _userRepository.GetById(id);
                _userRepository.Update(userInDb, user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        public void Delete(int id)
        {
            try
            {
                var userInDb = _userRepository.GetById(id);
                _userRepository.Delete(userInDb.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
