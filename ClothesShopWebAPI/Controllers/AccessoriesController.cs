using ClothesShop.DAL.Entities;
using ClothesShop.DAL.Interfaces;
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

    }
}
