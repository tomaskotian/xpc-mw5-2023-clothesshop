﻿using ClothesShop.Common.Enums;
using ClothesShop.DAL.Entities;
using ClothesShop.DAL.Interfaces;
using ClothesShop.DAL.Data;

namespace ClothesShop.DAL.Repository
{
    public class AccessoriesRepository : IAccessoriesRepository
    {
        private readonly DataContext _data;

        public AccessoriesRepository(DataContext data)
        {
            _data = data;
        }

        public List<AccessoriesEntity> GetAllAccessories()
        {
            return _data.AccessoriesData.ToList();
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

        public AccessoriesEntity GetAccessoryById(Guid id)
        {
            var accessories = _data.AccessoriesData.Where(c => c.Id == id).FirstOrDefault();
            return accessories;
        }

        public List<AccessoriesEntity> GetAccessoriesFiltered(string manufacturer_name, Sex sex, string sort)
        {
            var accessories = _data.AccessoriesData.OfType<AccessoriesEntity>();
            if (manufacturer_name != default)
                accessories = accessories.Where(s => s.Manufacturer.Name == manufacturer_name);
            if (sex != default)
                accessories = accessories.Where(s => s.Sex == sex);
            if (sort == "ByPrice")
                accessories = accessories.OrderBy(s => s.Price);

            return accessories.ToList();
        }
    }
}
