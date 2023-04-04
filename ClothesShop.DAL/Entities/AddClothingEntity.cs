﻿using ClothesShop.Common.Enums;
using ClothesShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ClothesShop.DAL.Entities
{
    public class AddClothingEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float Weight { get; set; }
        public uint Stock { get; set; }
        public Guid ManufacturerId { get; set; }
        public ManufacturerEntity Manufacturer { get; set; }
        public Guid ReviewId { get; set; }
        public ReviewEntity ReviewEntity { get; set; }
        public CategoryClothing CategoryClothing { get; set; }
        public SizeClothing SizeClothing { get; set; }
        public Sex Sex { get; set; }
    }
}