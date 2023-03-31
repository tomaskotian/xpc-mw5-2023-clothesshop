using System;

namespace ClothesShop.DAL.Entities
{
    public class ReviewEntity : IEntity
    {
        public Guid Id { get; set; }
        public uint Stars { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
