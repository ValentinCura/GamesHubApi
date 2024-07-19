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
        private readonly ISaleDetailRepository _saleDetailrepository;
        private readonly IProductRepository _productRepository;
        private readonly ISaleRepository _saleRepository;
        public SaleDetailService(ISaleDetailRepository saleDetailrepository, IProductRepository productRepository, ISaleRepository saleRepository)
        {
            _saleDetailrepository = saleDetailrepository;
            _productRepository = productRepository;
            _saleRepository = saleRepository;
        }

        public SaleDetail Add(SaleDetailForRequest saleDetailDto)
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
            return _saleDetailrepository.Add(saleDetail);
        }
    }

}
