using FarmManagementSystem.Domain.Entities;

namespace FarmManagementSystem.Domain.Interfaces.IRepositories
{
    public interface IFarmRepository
    {
        List<Farm> GetAll();
        Farm GetById(int Id);
        List<Farm> GetByUserId(int userId);
        void Add(Farm farm);
        void Update(Farm farmInDb, Farm farm);
        void Delete(Farm farm);
    }
}
