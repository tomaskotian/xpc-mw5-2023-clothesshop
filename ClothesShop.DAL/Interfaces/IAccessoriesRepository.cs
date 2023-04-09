
using ClothesShop.Common.Enums;
using ClothesShop.DAL.Entities;

namespace ClothesShop.DAL.Interfaces
{
    public interface IAccessoriesRepository
    {
        List<AccessoriesEntity> GetAllAccessories();
        void AddAccessory(AccessoriesEntity accessories);
        void RemoveAccessory(AccessoriesEntity accessories);
        AccessoriesEntity GetAccessoryById(Guid id);
        List<AccessoriesEntity> GetAccessoriesFiltered(string manufacturer_name, Sex sex, string sort);
    }
}
