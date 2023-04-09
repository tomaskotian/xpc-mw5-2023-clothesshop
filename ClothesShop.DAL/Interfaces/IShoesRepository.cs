using ClothesShop.Common.Enums;
using ClothesShop.DAL.Entities;

namespace ClothesShop.DAL.Interfaces
{
    public interface IShoesRepository
    {
        List<ShoesEntity> GetAllShoes();
        public void AddShoe(ShoesEntity shoes);
        void RemoveShoe(ShoesEntity shoes);
        ShoesEntity GetShoeById(Guid id);
        List<ShoesEntity> GetShoesFiltered(string manufacturer_name, SizeShoes size, Sex sex, string sort);
    }
}
