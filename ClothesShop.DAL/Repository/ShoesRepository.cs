using ClothesShop.Common.Enums;
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

        public void AddShoe(ShoesEntity shoes)
        {
            _data.AddEntity(shoes);
            CorrectManufacturer.AddComodities(shoes, _data);
        }

        public void RemoveShoe(ShoesEntity shoes)
        {
            CorrectManufacturer.DeleteComodities(shoes, _data);
            _data.Data.Remove(shoes);
        }

        public ShoesEntity GetShoeById(Guid id)
        {
            var shoes = _data.Data.OfType<ShoesEntity>().Where(c => c.Id == id).FirstOrDefault();
            return shoes;
        }

        public List<ShoesEntity> GetShoesFiltered(string manufacturer_name, SizeShoes size, Sex sex, string sort)
        {
            var shoes = _data.Data.OfType<ShoesEntity>();
            if (manufacturer_name != default)
                shoes = shoes.Where(s => s.Manufacturer.Name == manufacturer_name);
            if (size != default)
                shoes = shoes.Where(s => s.SizeShoes == size);
            if (sex != default)
                shoes = shoes.Where(s => s.Sex == sex);
            if (sort == "ByPrice")
                shoes = shoes.OrderBy(s => s.Price);

            return shoes.ToList();
        }
    }
}
