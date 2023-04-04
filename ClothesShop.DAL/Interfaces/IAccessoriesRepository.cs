
using ClothesShop.DAL.Entities;

namespace ClothesShop.DAL.Interfaces
{
    public interface IAccessoriesRepository
    {
        List<AccessoriesEntity> GetAllAccessories();
        void AddAccessories(AccessoriesEntity accessories);
        void RemoveAccessories(AccessoriesEntity accessories);
        AccessoriesEntity FindAccessories(Guid id);
    }
}
