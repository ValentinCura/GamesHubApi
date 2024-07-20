using Application.Dtos;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Services
{
    public interface IProductService
    {
        Product? GetByName(string name);
        Product? GetById(int id);
        List<Product> Get();
        Product Add(ProductForRequest productDto);
        Product Update(int productId, ProductForRequest productDto);
        void Remove(int productId);



    }
}
