using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ISaleDetailRepository : IBaseRepository<SaleDetail>
    {
        SaleDetail CheckSale(int ClientId, int ProductId);
        List<SaleDetail> GetBySale(int saleId, int clientId);
        List<SaleDetail> GetSaleRecords(int clientId);
    }
}
