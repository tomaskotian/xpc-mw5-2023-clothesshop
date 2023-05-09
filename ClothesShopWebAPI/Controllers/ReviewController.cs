using ClothesShop.DAL.DTOs;
using ClothesShop.DAL.Entities;
using ClothesShop.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ReviewEntity>))]
        [ProducesResponseType(400)]
        public IActionResult GetAllReviews()
        {
            var reviews = _reviewRepository.GetAllReviews();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(reviews);
        }

        [HttpPost]
        public IActionResult AddReview(ReviewDto reviewDto)
        {
            var review = new ReviewEntity()
            {
                Id = new Guid(),
                Stars = reviewDto.Stars,
                Title = reviewDto.Title,
                Description = reviewDto.Description,
            };

            _reviewRepository.AddReview(review);
            return Ok(review);
        }
    }
}
