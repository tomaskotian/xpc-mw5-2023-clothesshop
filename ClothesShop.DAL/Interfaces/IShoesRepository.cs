using ClothesShop.Common.Enums;
using ClothesShop.DAL.Entities;

namespace ClothesShop.DAL.Interfaces
{
    public interface IShoesRepository
    {
        Task<List<ShoesEntity>> GetAllShoes();
        public void AddShoe(ShoesEntity shoes);
        void RemoveShoe(ShoesEntity shoes);
        Task<ShoesEntity> GetShoeById(Guid id);
        Task<List<ShoesEntity>> GetShoesFiltered(string manufacturer_name, SizeShoes size, Sex sex, string sort);
    }
}
