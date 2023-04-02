using System;
using Bogus;
using ClothesShop.Common.Enums;
using ClothesShop.DAL.Entities;

namespace ClothesShop.DAL.Migrations;
public class InitialData : CommoditiesEntity
{   
    public static ICollection<CommoditiesEntity> GetCommoditiesEntities(int count)
    {
        ICollection<CommoditiesEntity> DataCollection = new List<CommoditiesEntity>();
        var Clothing = GetFakeClothingEntities(count);
        var Shoes = GetFakeShoesEntities(count);
        var Accessories = GetFakeAccessoriesEntities(count);

        foreach (ClothingEntity clothes in Clothing)
        {
            DataCollection.Add(clothes);
        }

        foreach (ShoesEntity shoes in Shoes)
        {
            DataCollection.Add(shoes);
        }

        foreach (AccessoriesEntity accessorie in Accessories)
        {
            DataCollection.Add(accessorie);
        }

        return DataCollection;
    }

    private static ICollection<ClothingEntity> GetFakeClothingEntities(int count)
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

    private static ICollection<AccessoriesEntity> GetFakeAccessoriesEntities(int count)
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

    private static ICollection<ShoesEntity> GetFakeShoesEntities(int count)
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
