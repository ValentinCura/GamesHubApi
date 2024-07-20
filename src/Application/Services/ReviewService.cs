using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System.Security.Claims;

namespace Application.Services
{
    public class ReviewService : IReviewService
    {
        
        private readonly IReviewRepository _reviewRepository;
        private readonly ISaleDetailRepository _saleDetailRepository;
        private readonly IProductRepository _productRepository;
        private readonly IClientRepository _clientRepository;
        public ReviewService( IReviewRepository reviewRepository, ISaleDetailRepository saleDetailRepository, IProductRepository productRepository, IClientRepository clientRepository)
        {
            _reviewRepository = reviewRepository;
            _saleDetailRepository = saleDetailRepository;
            _productRepository = productRepository;
            _clientRepository = clientRepository;

        }
        public Review Add(ReviewForRequest reviewDto, int clientId)
        {
           var product = _productRepository.GetById(reviewDto.ProductId);
           var client = _clientRepository.GetById(clientId);
           var sale = _saleDetailRepository.CheckSale(clientId,reviewDto.ProductId);
            if (sale != null)
            {
                var review = new Review()
                {
                    Content = reviewDto.Content,
                    ProductId = reviewDto.ProductId,
                    Product = product,
                    ClientId = clientId,
                    Client = client
                };
                return _reviewRepository.Add(review);
            }
            throw new Exception("No sale with client or product");
        }
        public Review GetById(int reviewId)
        {
            return _reviewRepository.GetById(reviewId);
        }
        public List<Review> GetByProduct (int id)
        {
            return _reviewRepository.GetByProduct(id);
        }
    }
}
