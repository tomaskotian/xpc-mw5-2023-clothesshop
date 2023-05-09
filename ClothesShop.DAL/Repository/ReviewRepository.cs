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
    internal class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _data;
        public void AddReview(ReviewEntity review)
        {
            _data.Add(review);
        }

        public ReviewEntity GetReviewById(Guid id)
        {
            var review = _data.ReviewsData.Where(c => c.Id == id).FirstOrDefault();
            return review;
        }

        public void RemoveReview(ReviewEntity review)
        {
            _data.ReviewsData.Remove(review);
        }
    }
}
