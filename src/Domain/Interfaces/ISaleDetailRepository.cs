using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ISaleDetailRepository : IBaseRepository<SaleDetail>
    {
        SaleDetail CheckSale(int ClientId, int ProductId);
    }
}
