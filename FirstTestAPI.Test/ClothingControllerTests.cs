using ClothesShop.Common.Enums;
using ClothesShop.DAL.Controllers;
using ClothesShop.DAL.Entities;
using ClothesShop.DAL.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
using Xunit;

namespace ClothesShop.DAL.Tests.Controllers
{
    public class ClothingControllerTests
    {
        private readonly ClothingController _clothingController;
        private readonly Mock<IClothingRepository> _clothingRepositoryMock;

        public ClothingControllerTests()
        {
            _clothingRepositoryMock = new Mock<IClothingRepository>();
            _clothingController = new ClothingController(_clothingRepositoryMock.Object);
        }

        [Fact]
        public void GetAllClothing_Returns_OkResult_With_All_Clothing()
        {
            // Arrange
            var expectedClothing = new List<ClothingEntity>
            {
                new ClothingEntity { Id = Guid.NewGuid(), Name = "T-Shirt", Price = 10, Stock = 100 },
                new ClothingEntity { Id = Guid.NewGuid(), Name = "Jeans", Price = 29, Stock = 50 },
                new ClothingEntity { Id = Guid.NewGuid(), Name = "Hoodie", Price = 39, Stock = 25 }
            };
            _clothingRepositoryMock.Setup(x => x.GetAllClothing()).Returns(expectedClothing);

            // Act
            var result = _clothingController.GetAllClothing() as OkObjectResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
            var actualClothing = result.Value as List<ClothingEntity>;
            actualClothing.Should().NotBeNull();
            actualClothing.Should().BeEquivalentTo(expectedClothing);
        }

        [Fact]
        public void GetClothingById_Returns_OkResult_With_Correct_Clothing()
        {
            // Arrange
            var id = Guid.NewGuid();
            var expectedClothing = new ClothingEntity { Id = id, Name = "T-Shirt", Price = 10, Stock = 100 };
            _clothingRepositoryMock.Setup(x => x.GetClothingById(id)).Returns(expectedClothing);

            // Act
            var result = _clothingController.GetClothingById(id) as OkObjectResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
            var actualClothing = result.Value as ClothingEntity;
            actualClothing.Should().NotBeNull();
            actualClothing.Should().BeEquivalentTo(expectedClothing);
        }
    }
}

        //[Fact]
        //public void GetClothingFiltered_Returns_OkResult_With_Filtered_Clothing()
        //{
        //    // Arrange
        //    var expectedClothing = new List<ClothingEntity>
        //    {
        //        new ClothingEntity { Id = Guid.NewGuid(), Name = "T-Shirt", Price = 10, Stock = 100 },
        //        new ClothingEntity { Id = Guid.NewGuid(), Name = "Jeans", Price = 29, Stock = 50 },
        //        new ClothingEntity { Id = Guid.NewGuid(), Name = "Hoodie", Price = 39, Stock = 25 }
        //    };
        //    _clothingRepositoryMock.Setup(x => x.GetClothingFiltered(null, SizeClothing.M, Sex.Male, null)).Returns(expectedClothing);
        //
        //    // Act
        //    var result = _clothingController.GetClothingFiltered(size: SizeClothing.M, sex: Sex.Male) as OkObjectResult;
        //
        //    // Assert
        //    result.Should().Not
