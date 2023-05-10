using ClothesShop.Common.Enums;
using ClothesShop.DAL.Entities;
using ClothesShop.DAL.Interfaces;
using ClothesShop.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace ClothesShop.DAL.Repository
{
    public class ClothingRepository : IClothingRepository
    {
        private readonly DataContext _data;   
        public ClothingRepository(DataContext data) 
        {
            _data = data;
        }

        public async Task<List<ClothingEntity>> GetAllClothing()
        {
            return await _data.ClothingData.ToListAsync();
        }

        public void AddClothing(ClothingEntity clothing)
        {
            _data.ClothingData.Add(clothing);
        }

        public void RemoveClothing(ClothingEntity clothing)
        {
            _data.ClothingData.Remove(clothing);
        }

        public async Task<ClothingEntity> GetClothingById(Guid id)
        {
            return await _data.ClothingData.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<ClothingEntity>> GetClothingFiltered(string manufacturer_name, SizeClothing size, Sex sex, string sort)
        {
            var clothing = _data.ClothingData.OfType<ClothingEntity>();
            if (manufacturer_name != default)
                clothing = clothing.Where(s => s.Manufacturer.Name == manufacturer_name);
            if (size != default)
                clothing = clothing.Where(s => s.SizeClothing == size);
            if (sex != default)
                clothing = clothing.Where(s => s.Sex == sex);
            if (sort == "ByPrice")
                clothing = clothing.OrderBy(s => s.Price);

            return await clothing.ToListAsync();
        }
    }
}
