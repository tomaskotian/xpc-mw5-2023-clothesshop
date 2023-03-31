using System;
using Bogus;
using ClothesShop.Common.Enums;
using ClothesShop.DAL.Entities;

namespace ClothesShop.DAL.Migrations;
public class InitialData : CommoditiesEntity, IClothes
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public float Weight { get; set; }
    public uint Stock { get; set; }
    public Guid ManufacturerId { get; set; }
    public ManufacturerEntity Manufacturer { get; set; }
    public Guid ReviewId { get; set; }
    public ReviewEntity ReviewEntity { get; set; }
    public CategoryClothing CategoryClothing { get; set; }
    public SizeClothing SizeClothing { get; set; }
    public Sex Sex { get; set; }

    public static List<ClothingEntity> GetFakeClothingEntities(int count)
    {
        Randomizer.Seed = new Random(895344);
        var Faker = new Faker();
        var lorem = new Bogus.DataSets.Lorem("en");
        var ClothingFaker = new Faker<ClothingEntity>()
            .RuleFor(c => c.Id, Guid.NewGuid())
            .RuleFor(c => c.Name, f => f.Commerce.ProductName())
            .RuleFor(c => c.Image, f => f.Internet.Url())
            .RuleFor(c => c.Description, f => f.Commerce.ProductDescription())
            .RuleFor(c => c.Price, f => f.Random.Float(10, 100))
            .RuleFor(c => c.Weight, f => f.Random.Float(0.5f, 3.0f))
            .RuleFor(c => c.Stock, f => f.Random.UInt(10, 100))
            .RuleFor(c => c.ManufacturerId, Guid.NewGuid())
            .RuleFor(c => c.Manufacturer, f => new ManufacturerEntity { Id = f.Random.Guid(), Name = f.Company.CompanyName(), Description = lorem.Sentence(), Logo = f.Internet.Url(), Origin = f.PickRandom<Origin>() })
            .RuleFor(c => c.ReviewId, Guid.NewGuid())
            .RuleFor(c => c.ReviewEntity, f => new ReviewEntity { Id = f.Random.Guid(), Stars = f.Random.UInt(1, 5), Title = f.Lorem.Paragraph(), Description = lorem.Sentence() })
            .RuleFor(c => c.CategoryClothing, f => f.PickRandom<CategoryClothing>())
            .RuleFor(c => c.SizeClothing, f => f.PickRandom<SizeClothing>())
            .RuleFor(c => c.Sex, f => f.PickRandom<Sex>());

        return ClothingFaker.Generate(count);
    }
}
