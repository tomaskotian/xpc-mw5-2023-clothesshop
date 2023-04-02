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
    }
}
