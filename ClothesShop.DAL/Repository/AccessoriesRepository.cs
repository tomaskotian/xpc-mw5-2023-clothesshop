using ClothesShop.Common.Enums;
using ClothesShop.DAL.Entities;
using ClothesShop.DAL.Interfaces;
using ClothesShop.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace ClothesShop.DAL.Repository
{
    public class AccessoriesRepository : IAccessoriesRepository
    {
        private readonly DataContext _data;

        public AccessoriesRepository(DataContext data) 
        {
            _data = data;
        }

        public async Task<List<AccessoriesEntity>> GetAllAccessories()
        {
            return await _data.AccessoriesData.ToListAsync();
        }

        public void AddAccessory(AccessoriesEntity accessories)
        {
            _data.AccessoriesData.Add(accessories);
            _data.SaveChanges();
        }

        public void RemoveAccessory(AccessoriesEntity accessories)
        {
            _data.AccessoriesData.Remove(accessories);
            _data.SaveChanges();
        }

        public async Task<AccessoriesEntity> GetAccessoryById(Guid id)
        {
            return await _data.AccessoriesData.Include(i => i.Manufacturer).FirstOrDefaultAsync(a => a.Id == id); ;
        }

        public async Task<List<AccessoriesEntity>> GetAccessoriesFiltered(string manufacturer_name, Sex sex, string sort)
        {
            var accessories = _data.AccessoriesData.OfType<AccessoriesEntity>();
            if (manufacturer_name != default)
                accessories = accessories.Where(s => s.Manufacturer.Name == manufacturer_name);
            if (sex != default)
                accessories = accessories.Where(s => s.Sex == sex);
            if (sort == "ByPrice")
                accessories = accessories.OrderBy(s => s.Price);

            return await accessories.ToListAsync();
        }
    }
}
