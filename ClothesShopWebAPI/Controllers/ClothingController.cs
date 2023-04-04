using ClothesShop.DAL.Entities;
using ClothesShop.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShop.DAL.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ClothingController : Controller
    {
        private readonly IClothingRepository _clothingRepository;

        public ClothingController(IClothingRepository clothingRepository) 
        {
            _clothingRepository = clothingRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ClothingEntity>))]
        public IActionResult GetAllClothing()
        {
            var clothing = _clothingRepository.GetAllClothing();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(clothing);
        }

        [HttpPost]
        public IActionResult AddClothing(AddClothingEntity addClothingEntity)
        {
            var clothing = new ClothingEntity()
            {
                Id = Guid.NewGuid(),
                Name = addClothingEntity.Name,
                Image = addClothingEntity.Image,
                Description = addClothingEntity.Description,
                Price = addClothingEntity.Price,
                Weight = addClothingEntity.Weight,
                Stock = addClothingEntity.Stock,
                ManufacturerId = addClothingEntity.ManufacturerId,
                Manufacturer = addClothingEntity.Manufacturer,
                ReviewId = addClothingEntity.ReviewId,
                ReviewEntity = addClothingEntity.ReviewEntity,
                CategoryClothing = addClothingEntity.CategoryClothing,
                SizeClothing = addClothingEntity.SizeClothing,
                Sex = addClothingEntity.Sex,
            };

            _clothingRepository.AddClothing(clothing);
            return Ok(clothing);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteClothing([FromRoute] Guid id) 
        {
            ClothingEntity clothing = _clothingRepository.FindClothingById(id);

            if (clothing == null)
                return NotFound();

            _clothingRepository.RemoveClothing(clothing);
            return Ok(clothing);
        }
    }
}
