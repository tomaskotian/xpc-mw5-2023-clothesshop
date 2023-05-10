using ClothesShop.Common.Enums;
using ClothesShop.DAL.DTOs;
using ClothesShop.DAL.Entities;
using ClothesShop.DAL.Interfaces;
using ClothesShop.DAL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShop.DAL.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClothingController : Controller
    {
        private readonly IClothingRepository _clothingRepository;
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IReviewRepository _reviewRepository;

        public ClothingController(IClothingRepository clothingRepository, IManufacturerRepository manufacturerRepository, IReviewRepository reviewRepository)
        {
            _clothingRepository = clothingRepository;
            _manufacturerRepository = manufacturerRepository;
            _reviewRepository = reviewRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ClothingEntity>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllClothing()
        {
            var clothing = await _clothingRepository.GetAllClothing();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(clothing);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetClothingById([FromRoute] Guid id)
        {
            var clothing = await _clothingRepository.GetClothingById(id);

            if (clothing == null)
                return NotFound();

            return Ok(clothing);
        }

        [HttpGet]
        [Route("details")]
        public async Task<IActionResult> GetClothingFiltered(string manufacturer_name = default, SizeClothing size = default, Sex sex = default, string sort = default)
        {
            var clothing = await _clothingRepository.GetClothingFiltered(manufacturer_name, size, sex, sort);

            if (clothing == null)
                return NotFound();

            return Ok(clothing);
        }

        [HttpPost]
        public async Task<IActionResult> AddClothing(ClothingDto clothingDto)
        {
            var manufacturer = await _manufacturerRepository.GetManufacturerById(clothingDto.ManufacturerId);
            var review = await _reviewRepository.GetReviewById(clothingDto.ReviewId);

            if (manufacturer == null || review == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var clothing = new ClothingEntity()
            {
                Id = Guid.NewGuid(),
                Name = clothingDto.Name,
                Image = clothingDto.Image,
                Description = clothingDto.Description,
                Price = clothingDto.Price,
                Weight = clothingDto.Weight,
                Stock = clothingDto.Stock,
                ManufacturerId = clothingDto.ManufacturerId,
                Manufacturer = manufacturer,
                ReviewId = clothingDto.ReviewId,
                ReviewEntity = review,
                CategoryClothing = clothingDto.CategoryClothing,
                SizeClothing = clothingDto.SizeClothing,
                Sex = clothingDto.Sex,
            };

            manufacturer.ClothingCommodities.Add(clothing);
            _manufacturerRepository.UpdateManufacturer(manufacturer);

            _clothingRepository.AddClothing(clothing);
            return Ok(clothing);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteClothing([FromRoute] Guid id) 
        {
            var clothing = await _clothingRepository.GetClothingById(id);

            if (clothing == null)
                return NotFound();

            _clothingRepository.RemoveClothing(clothing);
            return Ok(clothing);
        }
    }
}
