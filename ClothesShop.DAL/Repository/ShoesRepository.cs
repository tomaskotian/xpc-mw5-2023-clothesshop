using ClothesShop.DAL.Entities;
using ClothesShop.DAL.Interfaces;
using ClothesShop.DAL.Migrations;

namespace ClothesShop.DAL.Repository
{
    public class ShoesRepository : IShoesRepository
    {
        private readonly IFakeDatabase _fakeDatabase;

        public ShoesRepository(IFakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public Task<List<ShoesEntity>> GetAllShoes()
        {
            return _fakeDatabase.GetAllShoes();
        }

        public void AddShoes(ShoesEntity shoes)
        {
            _fakeDatabase.AddShoes(shoes);
        }

        public void RemoveShoes(ShoesEntity shoes)
        {
            _fakeDatabase.RemoveShoes(shoes);
        }

        public ShoesEntity FindShoesById(Guid id)
        {
            var shoes = _fakeDatabase.GetShoesById(id);
            return shoes;
        }
    }
}
