using Microsoft.EntityFrameworkCore;
using ClothesShop.DAL.Entities;

namespace ClothesShopEF
{
    public class ClothesDb : DbContext
    {
        public DbSet<ShoesEntity> shoesEntities { get; set; }
        public ClothesDb(DbContextOptions<ClothesDb> options) : base(options)
        {
        }
    }
}
