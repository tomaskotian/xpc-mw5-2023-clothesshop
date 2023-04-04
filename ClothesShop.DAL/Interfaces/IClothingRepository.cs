using ClothesShop.DAL.Entities;

namespace ClothesShop.DAL.Interfaces
{
    public interface IClothingRepository
    {
        Task <List<ClothingEntity>> GetAllClothing();
        void AddClothing(ClothingEntity clothing);
        void RemoveClothing(ClothingEntity clothing);
        ClothingEntity FindClothingById(Guid id);
    }
}
