using ClothesShop.Common.Enums;
using ClothesShop.DAL.Entities;

namespace ClothesShop.DAL.Interfaces
{
    public interface IClothingRepository
    {
        Task<List<ClothingEntity>> GetAllClothing();
        void AddClothing(ClothingEntity clothing);
        void RemoveClothing(ClothingEntity clothing);
        Task<ClothingEntity> GetClothingById(Guid id);
        Task<List<ClothingEntity>> GetClothingFiltered(string manufacturer_name, SizeClothing size, Sex sex, string sort);
    }
}
