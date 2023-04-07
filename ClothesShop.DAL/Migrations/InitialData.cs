using Bogus;
using ClothesShop.Common.Enums;
using ClothesShop.DAL.Entities;

namespace ClothesShop.DAL.Migrations;
public class InitialData 
{   
    public List<object> Data;
    public InitialData() 
    {
        
        Data = GetCommoditiesEntities(3);
        
    }

    public void AddEntity(object entity)
    {
        Data.Add(entity);
    }

    private static List<object> GetCommoditiesEntities(int count)
    {
        List<object> data = new List<object>();
        ICollection<ManufacturerEntity> Manufacturers = GetFakeManufacturers(5);
        var Clothing = GetFakeClothingEntities(count, Manufacturers);
        var Shoes = GetFakeShoesEntities(count, Manufacturers);
        var Accessories = GetFakeAccessoriesEntities(count, Manufacturers);

        foreach (ClothingEntity clothes in Clothing)
        {
            data.Add(clothes);
        }

        foreach (ShoesEntity shoes in Shoes)
        {
            data.Add(shoes);
        }

        foreach (AccessoriesEntity accessorie in Accessories)
        {
            data.Add(accessorie);
        }

        CorrectManufacturer.GetCorrectManufacturerBogus(data);
        return data;
    }

    private static ICollection<ClothingEntity> GetFakeClothingEntities(int count, ICollection<ManufacturerEntity> Manufacturers)
    {
        Randomizer.Seed = new Random(895344);
        var Faker = new Faker();
        var Lorem = new Bogus.DataSets.Lorem("en");
        var ClothingFaker = new Faker<ClothingEntity>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.Name, f => f.Commerce.ProductName())
            .RuleFor(c => c.Image, f => f.Internet.Url())
            .RuleFor(c => c.Description, f => f.Commerce.ProductDescription())
            .RuleFor(c => c.Price, f => f.Random.Float(10, 100))
            .RuleFor(c => c.Weight, f => f.Random.Float(0.5f, 3.0f))
            .RuleFor(c => c.Stock, f => f.Random.UInt(10, 100))
            .RuleFor(c => c.ManufacturerId, f => Guid.NewGuid())
            .RuleFor(c => c.Manufacturer, f => f.Random.CollectionItem(Manufacturers))
            .RuleFor(c => c.ReviewId, f => Guid.NewGuid())
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

    private static ICollection<AccessoriesEntity> GetFakeAccessoriesEntities(int count, ICollection<ManufacturerEntity> Manufacturers)
    {
        Randomizer.Seed = new Random(895333);
        var Faker = new Faker();
        var Lorem = new Bogus.DataSets.Lorem("en");
        var ClothingFaker = new Faker<AccessoriesEntity>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.Name, f => f.Commerce.ProductName())
            .RuleFor(c => c.Image, f => f.Internet.Url())
            .RuleFor(c => c.Description, f => f.Commerce.ProductDescription())
            .RuleFor(c => c.Price, f => f.Random.Float(10, 100))
            .RuleFor(c => c.Weight, f => f.Random.Float(0.5f, 3.0f))
            .RuleFor(c => c.Stock, f => f.Random.UInt(10, 100))
            .RuleFor(c => c.ManufacturerId, f => Guid.NewGuid())
            .RuleFor(c => c.Manufacturer, f => f.Random.CollectionItem(Manufacturers))
            .RuleFor(c => c.ReviewId, f => Guid.NewGuid())
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

    private static ICollection<ShoesEntity> GetFakeShoesEntities(int count, ICollection<ManufacturerEntity> Manufacturers)
    {
        Randomizer.Seed = new Random(623423);
        var Faker = new Faker();
        var Lorem = new Bogus.DataSets.Lorem("en");
        var ClothingFaker = new Faker<ShoesEntity>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.Name, f => f.Commerce.ProductName())
            .RuleFor(c => c.Image, f => f.Internet.Url())
            .RuleFor(c => c.Description, f => f.Commerce.ProductDescription())
            .RuleFor(c => c.Price, f => f.Random.Float(10, 100))
            .RuleFor(c => c.Weight, f => f.Random.Float(0.5f, 3.0f))
            .RuleFor(c => c.Stock, f => f.Random.UInt(10, 100))
            .RuleFor(c => c.ManufacturerId, f => Guid.NewGuid())
            .RuleFor(c => c.Manufacturer, f => f.Random.CollectionItem(Manufacturers))
            .RuleFor(c => c.ReviewId, f => Guid.NewGuid())
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
    
    private static ICollection<ManufacturerEntity> GetFakeManufacturers(int count)
    {
        Randomizer.Seed = new Random(623423);
        var Faker = new Faker();
        var Lorem = new Bogus.DataSets.Lorem("en");
        var ManufacturerFaker = new Faker<ManufacturerEntity>()
               .RuleFor(o => o.Id, f => f.Random.Guid())
               .RuleFor(o => o.Name, f => f.Company.CompanyName())
               .RuleFor(o => o.Description, f => Lorem.Paragraph())
               .RuleFor(o => o.Logo, f => f.Internet.Url())
               .RuleFor(o => o.Origin, f => f.PickRandom<Origin>());

        return ManufacturerFaker.Generate(count);
    }
}
