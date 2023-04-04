using Bogus;
using ClothesShop.DAL.Entities;
using ClothesShop.DAL.Interfaces;
using ClothesShop.Common.Enums;
using System;
using System.Linq;


namespace ClothesShop.DAL.Database
{
    public class FakeDatabase : IFakeDatabase
    {

        private readonly List<ClothingEntity> Clothing;

        private readonly List<ShoesEntity> Shoes;

        private readonly List<AccessoriesEntity> Accessories;

        private readonly int count = 15;

        public FakeDatabase()
        {
            Clothing = GetFakeClothingEntities(count).ToList();
            Shoes = GetFakeShoesEntities(count).ToList();
            Accessories = GetFakeAccessoriesEntities(count).ToList();
        }


        public Task<List<ClothingEntity>> GetAllClothing()
        {
            return Task.FromResult(Clothing);
        }

        public Task<List<ShoesEntity>> GetAllShoes()
        {
            return Task.FromResult(Shoes);
        }

        public Task<List<AccessoriesEntity>> GetAllAccessories()
        {
            return Task.FromResult(Accessories);
        }

        public Task AddClothing(ClothingEntity clothing)
        {
            Clothing.Add(clothing);
            return Task.CompletedTask;
        }

        public Task AddShoes(ShoesEntity shoes)
        {
            Shoes.Add(shoes);
            return Task.CompletedTask;
        }

        public Task AddAccessories(AccessoriesEntity accessories)
        {
            Accessories.Add(accessories);
            return Task.CompletedTask;
        }

        public Task RemoveClothing(ClothingEntity clothing)
        {
            Clothing.Remove(clothing);
            return Task.CompletedTask;
        }

        public Task RemoveShoes(ShoesEntity shoes)
        {
            Shoes.Remove(shoes);
            return Task.CompletedTask;
        }

        public Task RemoveAccessories(AccessoriesEntity accessories)
        {
            Accessories.Remove(accessories);
            return Task.CompletedTask;
        }

        public ClothingEntity GetClothingById(Guid id)
        {
            ClothingEntity clothing = Clothing.Where(c => c.Id == id).FirstOrDefault();
            return clothing;
        }

        public ShoesEntity GetShoesById(Guid id)
        {
            throw new NotImplementedException();
        }

        public AccessoriesEntity GetAccessoriesById(Guid id)
        {
            throw new NotImplementedException();
        }

        private static List<ClothingEntity> GetFakeClothingEntities(int count)
        {
            Randomizer.Seed = new Random(895344);
            var Faker = new Faker();
            var Lorem = new Bogus.DataSets.Lorem("en");
            var ClothingFaker = new Faker<ClothingEntity>()
                .RuleFor(c => c.Id, Guid.NewGuid())
                .RuleFor(c => c.Name, f => f.Commerce.ProductName())
                .RuleFor(c => c.Image, f => f.Internet.Url())
                .RuleFor(c => c.Description, f => f.Commerce.ProductDescription())
                .RuleFor(c => c.Price, f => f.Random.Float(10, 100))
                .RuleFor(c => c.Weight, f => f.Random.Float(0.5f, 3.0f))
                .RuleFor(c => c.Stock, f => f.Random.UInt(10, 100))
                .RuleFor(c => c.ManufacturerId, Guid.NewGuid())
                .RuleFor(c => c.Manufacturer, f => new ManufacturerEntity
                {
                    Id = f.Random.Guid(),
                    Name = f.Company.CompanyName(),
                    Description = Lorem.Paragraph(),
                    Logo = f.Internet.Url(),
                    Origin = f.PickRandom<Origin>()
                })
                .RuleFor(c => c.ReviewId,
                    Guid.NewGuid())
                .RuleFor(c => c.ReviewEntity, f => new ReviewEntity
                {
                    Id = f.Random.Guid(),
                    Stars = f.Random.UInt(1, 5),
                    Title = f.Lorem.Paragraph(),
                    Description = Lorem.Sentence()
                })
                .RuleFor(c => c.CategoryClothing, f => f.PickRandom<CategoryClothing>())
                .RuleFor(c => c.SizeClothing, f => f.PickRandom<SizeClothing>())
                .RuleFor(c => c.Sex, f => f.PickRandom<Sex>());

            return ClothingFaker.Generate(count);
        }

        private static List<AccessoriesEntity> GetFakeAccessoriesEntities(int count)
        {
            Randomizer.Seed = new Random(895333);
            var Faker = new Faker();
            var Lorem = new Bogus.DataSets.Lorem("en");
            var ClothingFaker = new Faker<AccessoriesEntity>()
                .RuleFor(c => c.Id, Guid.NewGuid())
                .RuleFor(c => c.Name, f => f.Commerce.ProductName())
                .RuleFor(c => c.Image, f => f.Internet.Url())
                .RuleFor(c => c.Description, f => f.Commerce.ProductDescription())
                .RuleFor(c => c.Price, f => f.Random.Float(10, 100))
                .RuleFor(c => c.Weight, f => f.Random.Float(0.5f, 3.0f))
                .RuleFor(c => c.Stock, f => f.Random.UInt(10, 100))
                .RuleFor(c => c.ManufacturerId, Guid.NewGuid())
                .RuleFor(c => c.Manufacturer, f => new ManufacturerEntity
                {
                    Id = f.Random.Guid(),
                    Name = f.Company.CompanyName(),
                    Description = Lorem.Paragraph(),
                    Logo = f.Internet.Url(),
                    Origin = f.PickRandom<Origin>()
                })
                .RuleFor(c => c.ReviewId, Guid.NewGuid())
                .RuleFor(c => c.ReviewEntity, f => new ReviewEntity
                {
                    Id = f.Random.Guid(),
                    Stars = f.Random.UInt(1, 5),
                    Title = f.Lorem.Paragraph(),
                    Description = Lorem.Sentence()
                })
                .RuleFor(c => c.CategoryAccessories, f => f.PickRandom<CategoryAccessories>())
                .RuleFor(c => c.Sex, f => f.PickRandom<Sex>());

            return ClothingFaker.Generate(count);
        }

        private static List<ShoesEntity> GetFakeShoesEntities(int count)
        {
            Randomizer.Seed = new Random(623423);
            var Faker = new Faker();
            var Lorem = new Bogus.DataSets.Lorem("en");
            var ClothingFaker = new Faker<ShoesEntity>()
                .RuleFor(c => c.Id, Guid.NewGuid())
                .RuleFor(c => c.Name, f => f.Commerce.ProductName())
                .RuleFor(c => c.Image, f => f.Internet.Url())
                .RuleFor(c => c.Description, f => f.Commerce.ProductDescription())
                .RuleFor(c => c.Price, f => f.Random.Float(10, 100))
                .RuleFor(c => c.Weight, f => f.Random.Float(0.5f, 3.0f))
                .RuleFor(c => c.Stock, f => f.Random.UInt(10, 100))
                .RuleFor(c => c.ManufacturerId, Guid.NewGuid())
                .RuleFor(c => c.Manufacturer, f => new ManufacturerEntity
                {
                    Id = f.Random.Guid(),
                    Name = f.Company.CompanyName(),
                    Description = Lorem.Paragraph(),
                    Logo = f.Internet.Url(),
                    Origin = f.PickRandom<Origin>()
                })
                .RuleFor(c => c.ReviewId, Guid.NewGuid())
                .RuleFor(c => c.ReviewEntity, f => new ReviewEntity
                {
                    Id = f.Random.Guid(),
                    Stars = f.Random.UInt(1, 5),
                    Title = f.Lorem.Paragraph(),
                    Description = Lorem.Sentence()
                })
                .RuleFor(c => c.CategoryShoes, f => f.PickRandom<CategoryShoes>())
                .RuleFor(c => c.SizeShoes, f => f.PickRandom<SizeShoes>())
                .RuleFor(c => c.Sex, f => f.PickRandom<Sex>());

            return ClothingFaker.Generate(count);
        }
    }
}
