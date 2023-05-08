using ClothesShop.DAL.Entities;
using ClothesShop.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ClothesShop.Common.Enums;


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

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetAccessoryById([FromRoute] Guid id)
        {
            var accessories = _accessoriesRepository.GetAccessoryById(id);

            if (accessories == null)
                return NotFound();

            return Ok(accessories);
        }

        [HttpGet]
        [Route("details")]
        public IActionResult GetAccessoriesFiltered(string manufacturer_name = default, Sex sex = default, string sort = default)
        {
            var accessories = _accessoriesRepository.GetAccessoriesFiltered(manufacturer_name, sex, sort);

            if (accessories == null)
                return NotFound();

            return Ok(accessories);
        }

        [HttpPost]
        public IActionResult AddAccessory(AddAccessoriesEntity addAccessoriesEntity)
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

            _accessoriesRepository.AddAccessory(accessories);
            return Ok(accessories);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteAccessory([FromRoute] Guid id)
        {
            var accessories = _accessoriesRepository.GetAccessoryById(id);

            if (accessories == null)
                return NotFound();

            _accessoriesRepository.RemoveAccessory(accessories);
            return Ok(accessories);
        }
    }
}
