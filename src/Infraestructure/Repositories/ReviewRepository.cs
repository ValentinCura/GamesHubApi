using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        private readonly ApplicationContext _context;
        public ReviewRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
        public List<Review> GetByProduct(int productId)
        {
            return _context.Reviews
            .Where(r => r.ProductId == productId)
            .ToList();
        }
    }
}
