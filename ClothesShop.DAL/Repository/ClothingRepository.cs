﻿using ClothesShop.Common.Enums;
using ClothesShop.DAL.Entities;
using ClothesShop.DAL.Interfaces;
using ClothesShop.DAL.Data;

namespace ClothesShop.DAL.Repository
{
    public class ClothingRepository : IClothingRepository
    {
        private readonly InitialData _data;   
        public ClothingRepository(InitialData data) 
        {
            _data = data;
        }

        public List<ClothingEntity> GetAllClothing()
        {
            return _data.ClothingData;
        }

        public void AddClothing(ClothingEntity clothing)
        {
            _data.AddClothing(clothing);
        }

        public void RemoveClothing(ClothingEntity clothing)
        {
            _data.ClothingData.Remove(clothing);
        }

        public ClothingEntity GetClothingById(Guid id)
        {
            var clothing = _data.ClothingData.Where(c => c.Id == id).FirstOrDefault();
            return clothing;
        }

        public List<ClothingEntity> GetClothingFiltered(string manufacturer_name, SizeClothing size, Sex sex, string sort)
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

            return clothing.ToList();
        }
    }
}
