using ClothesShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothesShop.DAL.Data
{
    public class DataContext : DbContext
    {
        public DbSet<ShoesEntity> ShoesEntities { get; set; }
        public DbSet<ClothingEntity> ClothingEntities { get; set; }
        public DbSet<AccessoriesEntity> AccessoriesEntities { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

    }
}
