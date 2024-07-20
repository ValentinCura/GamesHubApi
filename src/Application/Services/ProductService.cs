using Application.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public Product? GetByName(string name)
        {
            return _repository.GetByName(name);
        }

        public List<Product> Get()
        {
            return _repository.Get();
        }
        public Product? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Product Add( ProductForRequest productDto)
        {
            
            var product = new Product()
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Type = productDto.Type,
                Price = productDto.Price,
                Console = productDto.Console
            };
            return _repository.Add(product);
        }
        public Product Update(int productId,  ProductForRequest productDto)
        {
            
            var product = _repository.GetById(productId);

                product.Name = productDto.Name;
                product.Description = productDto.Description;
                product.Type = productDto.Type;
                product.Price = productDto.Price;
                product.Console = productDto.Console;
                
                
                return _repository.Update(product); 
            

        }
        public void Remove(int productId) 
        {
            var product = _repository.GetById(productId);
            if (product != null)
            {
                _repository.Remove(product);
            }
            
        }

    }
}
