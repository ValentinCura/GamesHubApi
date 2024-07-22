using Application.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISaleDetailService
    {
        SaleDetail Add(int clientId, SaleDetailForRequest saleDetailDto);
        List<SaleDetail> GetBySale(int saleId, int clientId);
        List<SaleDetail> GetSaleRecords(int clientId);
    }
}
