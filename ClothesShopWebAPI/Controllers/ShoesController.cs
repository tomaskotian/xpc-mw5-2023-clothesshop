using ClothesShop.DAL.Entities;
using ClothesShop.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoesController : Controller
    {
        private readonly IShoesRepository _shoesRepository;

        public ShoesController(IShoesRepository shoesRepository)
        {
            _shoesRepository= shoesRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ShoesEntity>))]
        public IActionResult GetAllShoes() 
        {
            var shoes = _shoesRepository.GetAllShoes();
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);
            return Ok(shoes);
        }

    }
}
