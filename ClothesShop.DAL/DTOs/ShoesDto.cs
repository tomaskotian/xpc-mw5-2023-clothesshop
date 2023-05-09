using ClothesShop.Common.Enums;
using ClothesShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.DAL.DTOs
{
    public class ShoesDto
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
        public CategoryShoes CategoryShoes { get; set; }
        public SizeShoes SizeShoes { get; set; }
        public Sex Sex { get; set; }
    }
}
