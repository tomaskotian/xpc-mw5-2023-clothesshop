using System;
using ClothesShop.Common.Enums;

namespace ClothesShop.DAL.Entities
{
    public class ManufacturerEntity : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public Origin Origin { get; set; }
        public List<object> Commodities { get; init; } = new List<object>();
    }
}
