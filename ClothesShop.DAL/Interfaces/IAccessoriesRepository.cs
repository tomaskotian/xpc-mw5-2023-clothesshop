
using ClothesShop.DAL.Entities;

namespace ClothesShop.DAL.Interfaces
{
    public interface IAccessoriesRepository
    {
        Task <List<AccessoriesEntity>> GetAllAccessories();
        void AddAccessories(AccessoriesEntity accessories);
        void RemoveAccessories(AccessoriesEntity accessories);
        AccessoriesEntity FindAccessoriesById(Guid id);
    }
}
