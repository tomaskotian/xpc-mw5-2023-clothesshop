﻿using ClothesShop.DAL.Entities;
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

        [HttpPost]
        public IActionResult AddShoes(AddShoesEntity addShoesEntity)
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

            _shoesRepository.AddShoes(shoes);
            return Ok(shoes);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteShoes([FromRoute] Guid id)
        {
            var shoes = _shoesRepository.FindShoes(id);

            if (shoes == null)
                return NotFound();

            _shoesRepository.RemoveShoes(shoes);
            return Ok(shoes);
        }

    }
}
