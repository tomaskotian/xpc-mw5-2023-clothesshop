using ClothesShop.DAL.Entities;
using ClothesShop.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ClothesShop.Common.Enums;
using ClothesShop.DAL.DTOs;
using ClothesShop.DAL.Repository;

namespace ClothesShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessoriesController : Controller
    {
        private readonly IAccessoriesRepository _accessoriesRepository;
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IReviewRepository _reviewRepository;

        AccessoriesController(IAccessoriesRepository accessoriesReposiory, IManufacturerRepository manufacturerRepository, IReviewRepository reviewRepository)
        {
            _accessoriesRepository = accessoriesReposiory;
            _manufacturerRepository = manufacturerRepository;
            _reviewRepository = reviewRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<AccessoriesEntity>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllAccessories()
        {
            var accessories = await _accessoriesRepository.GetAllAccessories();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(accessories);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetAccessoryById([FromRoute] Guid id)
        {
            var accessories = await _accessoriesRepository.GetAccessoryById(id);

            if (accessories == null)
                return NotFound();

            return Ok(accessories);
        }

        [HttpGet]
        [Route("details")]
        public async Task<IActionResult> GetAccessoriesFiltered(string manufacturer_name = default, Sex sex = default, string sort = default)
        {
            var accessories = await _accessoriesRepository.GetAccessoriesFiltered(manufacturer_name, sex, sort);

            if (accessories == null)
                return NotFound();

            return Ok(accessories);
        }

        [HttpPost]
        public async Task<IActionResult> AddAccessory(AccessoriesDto accessoriesDto)
        {
            var manufacturer = await _manufacturerRepository.GetManufacturerById(accessoriesDto.ManufacturerId);
            var review = await _reviewRepository.GetReviewById(accessoriesDto.ReviewId);

            if (manufacturer == null || review == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var accessories = new AccessoriesEntity()
            {
                Id = Guid.NewGuid(),
                Name = accessoriesDto.Name,
                Image = accessoriesDto.Image,
                Description = accessoriesDto.Description,
                Price = accessoriesDto.Price,
                Weight = accessoriesDto.Weight,
                Stock = accessoriesDto.Stock,
                ManufacturerId = accessoriesDto.ManufacturerId,
                Manufacturer = manufacturer,
                ReviewId = accessoriesDto.ReviewId,
                ReviewEntity = review,
                CategoryAccessories = accessoriesDto.CategoryAccessories,
                Sex = accessoriesDto.Sex,
            };

            manufacturer.AccessoriesCommodities.Add(accessories);

            _accessoriesRepository.AddAccessory(accessories);

            return Ok(accessories);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteAccessory([FromRoute] Guid id)
        {
            var accessories = await _accessoriesRepository.GetAccessoryById(id);

            if (accessories == null)
                return NotFound();

            _accessoriesRepository.RemoveAccessory(accessories);
            return Ok(accessories);
        }
    }
}
