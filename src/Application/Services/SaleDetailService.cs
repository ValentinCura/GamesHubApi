using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SaleDetailService : ISaleDetailService
    {
        private readonly ISaleDetailRepository _saleDetailRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISaleRepository _saleRepository;
        public SaleDetailService(ISaleDetailRepository saleDetailRepository, IProductRepository productRepository, ISaleRepository saleRepository)
        {
            _saleDetailRepository = saleDetailRepository;
            _productRepository = productRepository;
            _saleRepository = saleRepository;
        }

        public SaleDetail Add(int clientId, SaleDetailForRequest saleDetailDto)
        {
            var product = _productRepository.GetById(saleDetailDto.ProductId);
            var sale = _saleRepository.GetById(saleDetailDto.SaleId);
            var saleDetail = new SaleDetail()
            {
                SaleId = saleDetailDto.SaleId,
                Sale = sale,
                ProductId = saleDetailDto.ProductId,
                Product = product,
                Quantity = saleDetailDto.Quantity,
                

            };
            return _saleDetailRepository.Add(saleDetail);
        }
        public List<SaleDetail> GetBySale(int saleId, int clientId)
        {
            return _saleDetailRepository.GetBySale(saleId, clientId);
        }
        public List<SaleDetail> GetSaleRecords(int clientId)
        {
            return _saleDetailRepository.GetSaleRecords(clientId);
        }
    }

}
