using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IReviewRepository : IBaseRepository<Review>
    {
        List<Review> GetByProduct(int productId);
        bool CheckReview(int clientId, int reviewId);
    }
}
