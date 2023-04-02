using ClothesShop.DAL.Entities;
using ClothesShop.DAL.Interfaces;
using ClothesShop.DAL.Migrations;


namespace ClothesShop.DAL.Repository
{
    public class ClothingRepository : IClothingRepository
    {
        private readonly InitialData _data;   
        public ClothingRepository(InitialData data) 
        {
            _data = data;
        }

        public List<ClothingEntity> GetAllClothing()
        {
            return _data.Data.OfType<ClothingEntity>().ToList();
        }
    }
}
