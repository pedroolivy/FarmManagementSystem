using FarmManagementSystem.Domain.Entities;
using FarmManagementSystem.Domain.Interfaces.IRepositories;
using FarmManagementSystem.Services.Dtos;

namespace FarmManagementSystem.Services.Services
{
    public class UserService(IUserRepository userRepository)
    {
        private readonly IUserRepository _userRepository = userRepository;

        public List<User> GetAll()
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

        public void Add(UserDto userDto)
        {
            try
            {
                var user = new User
                {
                    Id = userDto.Id,
                    UserName = userDto.UserName,
                    Email = userDto.Email,
                    PassWord = userDto.PassWord,
                    Position = userDto.Position
                };

                user.Validate();
                _userRepository.Add(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(UserDto userDto)
        {
            try
            {
                var userInDb = _userRepository.GetById(userDto.Id);
                var user = new User
                {
                    Id = userDto.Id,
                    UserName = userDto.UserName,
                    Email = userDto.Email,
                    PassWord = userDto.PassWord,
                    Position = userDto.Position
                };

                user.Validate();
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
                _userRepository.Delete(userInDb);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
