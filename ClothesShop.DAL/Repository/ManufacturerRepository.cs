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
        }

        public void AddManufacturer(ManufacturerEntity manufacturer)
        {
            _data.ManufacturersData.Add(manufacturer);
            _data.SaveChanges();
        }

        public List<ManufacturerEntity> GetAllManufacturers()
        {
            return _data.ManufacturersData.ToList();
        }

        public ManufacturerEntity GetManufacturerById(Guid id)
        {
            var manufacturer = _data.ManufacturersData.Where(c => c.Id == id).FirstOrDefault();
            return manufacturer;
        }

        public void RemoveManufacturer(ManufacturerEntity manufacturer)
        {
            _data.ManufacturersData.Remove(manufacturer);
            _data.SaveChanges();
        }
    }
}
