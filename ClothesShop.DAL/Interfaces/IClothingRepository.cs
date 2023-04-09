using ClothesShop.Common.Enums;
using ClothesShop.DAL.Entities;

namespace ClothesShop.DAL.Interfaces
{
    public interface IClothingRepository
    {
        List<ClothingEntity> GetAllClothing();
        void AddClothing(ClothingEntity clothing);
        void RemoveClothing(ClothingEntity clothing);
        ClothingEntity FindClothing(Guid id);
        List<ClothingEntity> GetClothingFiltered(string manufacturer_name, SizeClothing size, Sex sex, string sort);
    }
}
