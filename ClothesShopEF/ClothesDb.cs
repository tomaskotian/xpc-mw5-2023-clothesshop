using Microsoft.EntityFrameworkCore;
using ClothesShop.DAL.Entities;

namespace ClothesShopEF
{
    public class ClothesDb : DbContext
    {
        public DbSet<ShoesEntity> ShoesEntities { get; set; }
        public DbSet<ClothingEntity> ClothingEntities { get; set; }
        public DbSet<AccessoriesEntity> AccessoriesEntities { get; set; }

        public ClothesDb(DbContextOptions<ClothesDb> options) : base(options)
        {
        }
    }
}
