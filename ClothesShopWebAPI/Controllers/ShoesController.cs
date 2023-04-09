using ClothesShop.Common.Enums;
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
        public IActionResult AddShoe(AddShoesEntity addShoesEntity)
        {
            var shoes = new ShoesEntity()
            {
                Id = Guid.NewGuid(),
                Name = addShoesEntity.Name,
                Image = addShoesEntity.Image,
                Description = addShoesEntity.Description,
                Price = addShoesEntity.Price,
                Weight = addShoesEntity.Weight,
                Stock = addShoesEntity.Stock,
                ManufacturerId = addShoesEntity.ManufacturerId,
                Manufacturer = addShoesEntity.Manufacturer,
                ReviewId = addShoesEntity.ReviewId,
                ReviewEntity = addShoesEntity.ReviewEntity,
                CategoryShoes = addShoesEntity.CategoryShoes,
                SizeShoes = addShoesEntity.SizeShoes,
                Sex = addShoesEntity.Sex,
            };

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
