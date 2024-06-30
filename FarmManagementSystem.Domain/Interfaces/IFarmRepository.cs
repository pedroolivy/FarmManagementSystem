using FarmManagementSystem.Domain.Entities;

namespace FarmManagementSystem.Domain.Interfaces
{
    public interface IFarmRepository
    {
        ICollection<Farm> GetAll();
        Farm GetById(int Id);
        ICollection<Farm> GetByUserId(int userId);
        void Add(Farm farm);
        void Update(Farm farm);
        void Delete(int Id);
    }
}
