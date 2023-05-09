using ClothesShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.DAL.Interfaces
{
    internal interface IReviewRepository
    {
        void AddReview(ReviewEntity review);
        ReviewEntity GetReviewById(Guid id);
        void RemoveReview(ReviewEntity review);
    }
}
