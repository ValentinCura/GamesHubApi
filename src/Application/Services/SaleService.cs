using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SaleService : ISaleService
    {
        private readonly IProductRepository _productRepository;
        private readonly ISaleRepository _saleRepository;

        public SaleService(IProductRepository productRepository, ISaleRepository saleRepository)
        {
            _productRepository = productRepository; 
            _saleRepository = saleRepository;
        }
        public Sale Add(Sale saleToAdd)
        { 
                return _saleRepository.Add(saleToAdd);
        }
            
    }
}
