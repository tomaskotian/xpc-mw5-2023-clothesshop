using ClothesShop.Common.Enums;
using ClothesShop.DAL.DTOs;
using ClothesShop.DAL.Entities;
using ClothesShop.DAL.Interfaces;
using ClothesShop.DAL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoesController : Controller
    {
        private readonly IShoesRepository _shoesRepository;
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IReviewRepository _reviewRepository;

        public ShoesController(IShoesRepository shoesRepository, IManufacturerRepository manufacturerRepository, IReviewRepository reviewRepository)
        {
            _shoesRepository = shoesRepository;
            _manufacturerRepository = manufacturerRepository;
            _reviewRepository = reviewRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ShoesEntity>))]
        [ProducesResponseType(400)]
        public IActionResult GetAllShoes()
        {
            var shoes = _shoesRepository.GetAllShoes();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(shoes);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetShoeById([FromRoute] Guid id)
        {
            var shoes = _shoesRepository.GetShoeById(id);

            if (shoes == null)
                return NotFound();

            return Ok(shoes);
        }

        [HttpGet]
        [Route("details")]
        public IActionResult GetShoesFiltered(string manufacturer_name = default, SizeShoes size = default, Sex sex = default, string sort = default)
        {
            var shoes = _shoesRepository.GetShoesFiltered(manufacturer_name, size, sex, sort);

            if (shoes == null)
                return NotFound();

            return Ok(shoes);
        }


        [HttpPost]
        public IActionResult AddShoe(ShoesDto shoesDto)
        {
            var manufacturer = _manufacturerRepository.GetManufacturerById(shoesDto.ManufacturerId);
            if (manufacturer == null)
            {
                return BadRequest();
            }

            var review = _reviewRepository.GetReviewById(shoesDto.ReviewId);
            if (review == null)
            {
                return BadRequest();
            }

            var shoes = new ShoesEntity()
            {
                Id = Guid.NewGuid(),
                Name = shoesDto.Name,
                Image = shoesDto.Image,
                Description = shoesDto.Description,
                Price = shoesDto.Price,
                Weight = shoesDto.Weight,
                Stock = shoesDto.Stock,
                ManufacturerId = shoesDto.ManufacturerId,
                Manufacturer = manufacturer,
                ReviewId = shoesDto.ReviewId,
                ReviewEntity = review,
                CategoryShoes = shoesDto.CategoryShoes,
                SizeShoes = shoesDto.SizeShoes,
                Sex = shoesDto.Sex,
            };

            manufacturer.ShoesCommodities.Add(shoes);
            _manufacturerRepository.UpdateManufacturer(manufacturer);

            _shoesRepository.AddShoe(shoes);
            return Ok(shoes);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteShoe([FromRoute] Guid id)
        {
            var shoes = _shoesRepository.GetShoeById(id);

            if (shoes == null)
                return NotFound();

            _shoesRepository.RemoveShoe(shoes);
            return Ok(shoes);
        }

    }
}
