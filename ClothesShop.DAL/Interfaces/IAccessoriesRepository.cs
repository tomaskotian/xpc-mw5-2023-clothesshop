
using ClothesShop.Common.Enums;
using ClothesShop.DAL.Entities;

namespace ClothesShop.DAL.Interfaces
{
    public interface IAccessoriesRepository
    {
        Task<List<AccessoriesEntity>> GetAllAccessories();
        void AddAccessory(AccessoriesEntity accessories);
        void RemoveAccessory(AccessoriesEntity accessories);
        Task<AccessoriesEntity> GetAccessoryById(Guid id);
        Task<List<AccessoriesEntity>> GetAccessoriesFiltered(string manufacturer_name, Sex sex, string sort);
    }
}
