using ClothesShop.DAL.Entities;
using ClothesShop.DAL.Interfaces;
using ClothesShop.DAL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessoriesController : Controller
    {
        private readonly IAccessoriesRepository _accessoriesRepository;

        public AccessoriesController(IAccessoriesRepository accessoriesReposiory)
        {
            _accessoriesRepository = accessoriesReposiory;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<AccessoriesEntity>))]
        public IActionResult GetAllAccessories()
        {
            var accessories = _accessoriesRepository.GetAllAccessories();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(accessories);
        }

        [HttpPost]
        public IActionResult AddAccessories(AddAccessoriesEntity addAccessoriesEntity)
        {
            var accessories = new AccessoriesEntity()
            {
                Id = Guid.NewGuid(),
                Name = addAccessoriesEntity.Name,
                Image = addAccessoriesEntity.Image,
                Description = addAccessoriesEntity.Description,
                Price = addAccessoriesEntity.Price,
                Weight = addAccessoriesEntity.Weight,
                Stock = addAccessoriesEntity.Stock,
                ManufacturerId = addAccessoriesEntity.ManufacturerId,
                Manufacturer = addAccessoriesEntity.Manufacturer,
                ReviewId = addAccessoriesEntity.ReviewId,
                ReviewEntity = addAccessoriesEntity.ReviewEntity,
                CategoryAccessories = addAccessoriesEntity.CategoryAccessories,
                Sex = addAccessoriesEntity.Sex,
            };

            _accessoriesRepository.AddAccessories(accessories);
            return Ok(accessories);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteAccessories([FromRoute] Guid id)
        {
            var accessories = _accessoriesRepository.FindAccessoriesById(id);

            if (accessories == null)
                return NotFound();

            _accessoriesRepository.RemoveAccessories(accessories);
            return Ok(accessories);
        }
    }
}
