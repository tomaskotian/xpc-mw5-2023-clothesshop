﻿using System;
using ClothesShop.Common.Enums;

namespace ClothesShop.DAL.Entities
{
    public interface IClothes : IEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float Weight { get; set; }
        public uint Stock { get; set; }
        public Guid ManufacturerId { get; set; }
        public ManufacturerEntity? Manufacturer { get; set; }
        public Guid ReviewId { get; set; }
        public ReviewEntity? ReviewEntity { get; set; }
        public Sex Sex { get; set; }

    }
}
