using ClothesShop.DAL.Entities;
using ClothesShop.DAL.Interfaces;
using ClothesShop.DAL.Migrations;

namespace ClothesShop.DAL.Repository
{
    public class AccessoriesRepository : IAccessoriesRepository
    {
        private readonly InitialData _data;

        public AccessoriesRepository(InitialData data) 
        {
            _data = data;
        }

        public List<AccessoriesEntity> GetAllAccessories()
        {
            return _data.Data.OfType<AccessoriesEntity>().ToList();
        }

        public void AddAccessories(AccessoriesEntity accessories)
        {
            _data.AddEntity(accessories);
        }
    }
}
