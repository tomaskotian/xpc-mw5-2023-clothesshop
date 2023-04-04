using ClothesShop.DAL.Entities;
using ClothesShop.DAL.Interfaces;
using ClothesShop.DAL.Migrations;

namespace ClothesShop.DAL.Repository
{
    public class ShoesRepository : IShoesRepository
    {
        private readonly InitialData _data;
        public ShoesRepository(InitialData data)
        {
            _data = data;
        }

        public List<ShoesEntity> GetAllShoes()
        {
            return _data.Data.OfType<ShoesEntity>().ToList();
        }

        public void AddShoes(ShoesEntity shoes)
        {
            _data.AddEntity(shoes);
        }
    }
}
