using ClothesShop.DAL.Entities;

namespace ClothesShop.DAL.Interfaces
{
    public interface IShoesRepository
    {
        Task<List<ShoesEntity>> GetAllShoes();
        public void AddShoes(ShoesEntity shoes);
        void RemoveShoes(ShoesEntity shoes);
        ShoesEntity FindShoesById(Guid id);
    }
}
