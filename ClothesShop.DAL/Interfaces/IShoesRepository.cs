using ClothesShop.DAL.Entities;

namespace ClothesShop.DAL.Interfaces
{
    public interface IShoesRepository
    {
        List<ShoesEntity> GetAllShoes();
        public void AddShoes(ShoesEntity shoes);
        void RemoveShoes(ShoesEntity shoes);
        ShoesEntity FindShoes(Guid id);
    }
}
