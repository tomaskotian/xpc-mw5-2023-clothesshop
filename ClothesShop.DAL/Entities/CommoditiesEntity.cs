using System;
using ClothesShop.Common.Enums;

namespace ClothesShop.DAL.Entities
{
    public class CommoditiesEntity : IEntity
    {
        public Guid Id { get; set; }
        public ICollection<ClothingEntity> ClothingCommodities { get; set; }
        public ICollection<ShoesEntity> ShoesCommodities { get;set; }
        public ICollection<AccessoriesEntity> AccessoriesCommodities { get; set;  }
    }
}

