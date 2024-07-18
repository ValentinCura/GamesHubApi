using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IProductRepository _productRepository;
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IProductRepository productRepository, IReviewRepository reviewRepository)
        {
            _productRepository = productRepository;
            _reviewRepository = reviewRepository;
        }
        public Review Add(ReviewForRequest reviewDto)
        {

            var product = _productRepository.GetById(reviewDto.ProductId);
                
                    var Review = new Review()
                    {
                        Content = reviewDto.Content,
                        Product = product
                    };
                return _reviewRepository.Add(Review);

                
           
        }
    }
}
