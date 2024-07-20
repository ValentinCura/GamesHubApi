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
        public SaleDetail CheckSale(int clientId, int productId)
        {
            var saleDetail = _context.SaleDetails
            .Include(sd => sd.Sale)
            .Include(sd => sd.Product) 
            .FirstOrDefault(sd => sd.Sale.ClientId == clientId && sd.ProductId == productId);
            return saleDetail;
        }
        public List<SaleDetail> GetBySale(int saleId,int clientId) 
        {
            return _context.SaleDetails
                .Include(sd => sd.Sale)
                .Include(sd => sd.Product)
                .Where(sd => sd.SaleId == saleId && sd.Sale.ClientId == clientId)
                .ToList();
        }
        public List<SaleDetail> GetSaleRecords(int clientId)
        {
            return _context.SaleDetails
            .Include(sd => sd.Sale) 
            .Include(sd => sd.Product) 
            .Where(sd => sd.Sale.ClientId == clientId)
            .ToList();
        }
    }
}
