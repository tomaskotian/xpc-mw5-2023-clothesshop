using ClothesShop.DAL.Data;
using ClothesShop.DAL.Entities;
using ClothesShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.DAL.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _data;

        public ReviewRepository(DataContext data)
        {
            _data = data;
        }

        public void AddReview(ReviewEntity review)
        {
            _data.ReviewsData.Add(review);
            _data.SaveChanges();
        }

        public List<ReviewEntity> GetAllReviews()
        {
            return _data.ReviewsData.ToList();
        }

        public ReviewEntity GetReviewById(Guid id)
        {
            var review = _data.ReviewsData.Where(c => c.Id == id).FirstOrDefault();
            return review;
        }

        public void RemoveReview(ReviewEntity review)
        {
            _data.ReviewsData.Remove(review);
            _data.SaveChanges();
        }
    }
}
