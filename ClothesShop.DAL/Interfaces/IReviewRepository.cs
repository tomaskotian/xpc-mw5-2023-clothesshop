using ClothesShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.DAL.Interfaces
{
    public interface IReviewRepository
    {
        Task<List<ReviewEntity>> GetAllReviews();
        void AddReview(ReviewEntity review);
        Task<ReviewEntity> GetReviewById(Guid id);
        void RemoveReview(ReviewEntity review);
    }
}
