using ClothesShop.DAL.Data;
using ClothesShop.DAL.Entities;
using ClothesShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.DAL.Repository
{
    internal class ManufacturerRepository : IManufacturerRepository
    {
        private readonly DataContext _data;
        public void AddManufacturer(ManufacturerEntity manufacturer)
        {
            _data.Add(manufacturer);
        }

        public ManufacturerEntity GetManufacturerById(Guid id)
        {
            var manufacturer = _data.ManufacturersData.Where(c => c.Id == id).FirstOrDefault();
            return manufacturer;
        }

        public void RemoveManufacturer(ManufacturerEntity manufacturer)
        {
            _data.ManufacturersData.Remove(manufacturer);
        }
    }
}
