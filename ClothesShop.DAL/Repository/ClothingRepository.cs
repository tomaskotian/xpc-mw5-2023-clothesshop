using ClothesShop.DAL.Entities;
using ClothesShop.DAL.Interfaces;
using ClothesShop.DAL.Migrations;

namespace ClothesShop.DAL.Repository
{
    public class ClothingRepository : IClothingRepository
    {
        private readonly IFakeDatabase _fakeDatabase;

        public ClothingRepository(IFakeDatabase fakeDatabase) 
        {
            _fakeDatabase = fakeDatabase;
        }

        public Task<List<ClothingEntity>> GetAllClothing()
        {
            return _fakeDatabase.GetAllClothing();
        }

        public void AddClothing(ClothingEntity clothing)
        {
            _fakeDatabase.AddClothing(clothing);
        }

        public void RemoveClothing(ClothingEntity clothing)
        {
            _fakeDatabase.RemoveClothing(clothing);
        }

        public ClothingEntity FindClothingById(Guid id)
        {
            var clothing = _fakeDatabase.GetClothingById(id);
            return clothing;
        }
    }
}
