using ClothesShop.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.DAL.DTOs
{
    public class ReviewDto
    {
        public uint Stars { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
