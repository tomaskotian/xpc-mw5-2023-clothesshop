using ClothesShop.Common.Enums;
using ClothesShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.DAL.DTOs
{
    public class ManufacturerDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public Origin Origin { get; set; }
    }
}
