using ClothesShop.Common.Enums;
using ClothesShop.DAL.Entities;
using ClothesShop.DAL.Interfaces;
using ClothesShop.DAL.Data;

namespace ClothesShop.DAL.Repository
{
    public class ShoesRepository : IShoesRepository
    {
        private readonly DataContext _data;
        public ShoesRepository(DataContext data)
        {
            _data = data;
        }

        public List<ShoesEntity> GetAllShoes()
        {
            return _data.ShoesData.ToList();
        }

        public void AddShoe(ShoesEntity shoes)
        {
            _data.ShoesData.Add(shoes);
            _data.SaveChanges();
        }

        public void RemoveShoe(ShoesEntity shoes)
        {
            _data.ShoesData.Remove(shoes);
            _data.SaveChanges();
        }

        public ShoesEntity GetShoeById(Guid id)
        {
            var shoes = _data.ShoesData.Where(c => c.Id == id).FirstOrDefault();
            return shoes;
        }

        public List<ShoesEntity> GetShoesFiltered(string manufacturer_name, SizeShoes size, Sex sex, string sort)
        {
            var shoes = _data.ShoesData.OfType<ShoesEntity>();
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
