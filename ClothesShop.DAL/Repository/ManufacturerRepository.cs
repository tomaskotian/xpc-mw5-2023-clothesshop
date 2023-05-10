using ClothesShop.DAL.Data;
using ClothesShop.DAL.Entities;
using ClothesShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.DAL.Repository
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly DataContext _data;

        public ManufacturerRepository(DataContext data)
        {
            _data = data;
        }

        public void UpdateManufacturer(ManufacturerEntity manufacturer)
        {
            _data.ManufacturersData.Update(manufacturer);
            _data.SaveChanges();
        }

        public void AddManufacturer(ManufacturerEntity manufacturer)
        {
            _data.ManufacturersData.Add(manufacturer);
            _data.SaveChanges();
        }

        public async Task<List<ManufacturerEntity>> GetAllManufacturers()
        {
            return await _data.ManufacturersData.ToListAsync();
        }

        public async Task<ManufacturerEntity> GetManufacturerById(Guid id)
        {
            var manufacturer = _data.ManufacturersData
                                            .Include(m => m.AccessoriesCommodities)
                                            .Include(m => m.ClothingCommodities)
                                            .Include(m => m.ShoesCommodities)
                                            .Where(m => m.Id == id)
                                            .FirstOrDefaultAsync();
            return await manufacturer;
        }

        public void RemoveManufacturer(ManufacturerEntity manufacturer)
        {
            _data.ManufacturersData.Remove(manufacturer);
            _data.SaveChanges();
        }
    }
}
