using ClothesShop.DAL.Entities;

namespace ClothesShop.DAL.Interfaces
{
    public interface IShoesRepository
    {
        List<ShoesEntity> GetAllShoes();
    }
}
