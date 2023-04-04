using ClothesShop.DAL.Entities;
using ClothesShop.DAL.Interfaces;
using ClothesShop.DAL.Migrations;

namespace ClothesShop.DAL.Repository
{
    public class AccessoriesRepository : IAccessoriesRepository
    {
        private readonly IFakeDatabase _fakeDatabase;

        public AccessoriesRepository(IFakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public Task<List<AccessoriesEntity>> GetAllAccessories()
        {
            return _fakeDatabase.GetAllAccessories();
        }

        public void AddAccessories(AccessoriesEntity accessories)
        {
            _fakeDatabase.AddAccessories(accessories);
        }

        public void RemoveAccessories(AccessoriesEntity accessories)
        {
            _fakeDatabase.RemoveAccessories(accessories);
        }

        public AccessoriesEntity FindAccessoriesById(Guid id)
        {
            var accessories = _fakeDatabase.GetAccessoriesById(id);
            return accessories;
        }
    }
}
