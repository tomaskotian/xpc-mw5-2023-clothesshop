using ClothesShop.DAL.DTOs;
using ClothesShop.DAL.Entities;
using ClothesShop.DAL.Interfaces;
using ClothesShop.DAL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : Controller
    {
        private readonly IManufacturerRepository _manufacturerRepository;

        public ManufacturerController( IManufacturerRepository manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ManufacturerEntity>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllManufacturers()
        {
            var manufacturers = await _manufacturerRepository.GetAllManufacturers();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(manufacturers);
        }

        [HttpPost]
        public async Task<IActionResult> AddManufacturer(ManufacturerDto manufacturerDto)
        {
            var manufacturer = new ManufacturerEntity()
            {
                Id = new Guid(),
                Name = manufacturerDto.Name,
                Description = manufacturerDto.Description,
                Logo = manufacturerDto.Logo,
                Origin= manufacturerDto.Origin,               
            };

            _manufacturerRepository.AddManufacturer(manufacturer);
            return Ok(manufacturer);
        }
    }
}
