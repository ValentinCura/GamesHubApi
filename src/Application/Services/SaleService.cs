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
        private readonly ISaleRepository _saleRepository;
        private readonly IClientRepository _clientRepository;

        public SaleService( ISaleRepository saleRepository, IClientRepository clientRepository)
        {
            _saleRepository = saleRepository;
            _clientRepository = clientRepository;
        }
        public Sale Add(int clientId)
        {
            var client = _clientRepository.GetById(clientId);
            if (client == null)
            {
                throw new Exception("Client not found.");
            }
            var sale = new Sale()
                {
                    ClientId = clientId,
                    Client = client
                };
                return _saleRepository.Add(sale);
        }
        public Sale GetById(int id)
        {
            return _saleRepository.GetById(id);
        }
    }
}
