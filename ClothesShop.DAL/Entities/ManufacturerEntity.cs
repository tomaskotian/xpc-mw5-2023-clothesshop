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
        public List<ShoesEntity> ShoesCommodities { get; set; } = new List<ShoesEntity>();
        public List<ClothingEntity> ClothingCommodities { get; set; } = new List<ClothingEntity>();
        public List<AccessoriesEntity> AccessoriesCommodities { get; set; } = new List<AccessoriesEntity>();
    }
}