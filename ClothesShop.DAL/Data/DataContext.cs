using ClothesShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothesShop.DAL.Data
{
    public class DataContext : DbContext
    {
        public DbSet<ShoesEntity> ShoesData { get; set; }
        public DbSet<ClothingEntity> ClothingData { get; set; }
        public DbSet<AccessoriesEntity> AccessoriesData { get; set; }
        public DbSet<ManufacturerEntity> ManufacturersData { get; set; }
        public DbSet<ReviewEntity> ReviewsData { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

    }
}
