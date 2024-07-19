using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Infraestructure.Repositories
{
    public class SaleDetailRepository : BaseRepository<SaleDetail>, ISaleDetailRepository
    {
        private readonly ApplicationContext _context;
        public SaleDetailRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
        public SaleDetail CheckSale(int ClientId, int ProductId)
        {
            var saleDetail = _context.SaleDetails
            .Include(sd => sd.Sale)
            .Include(sd => sd.Product) 
            .FirstOrDefault(sd => sd.Sale.ClientId == ClientId && sd.ProductId == ProductId);
            return saleDetail;
        }
    }
}
