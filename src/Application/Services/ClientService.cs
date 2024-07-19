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
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public Client Add(ClientForRequest clientDto)
        {
            var Client = new Client()
            {
                Name = clientDto.Name,
                LastName = clientDto.LastName,
                Username = clientDto.Username,
                Password = clientDto.Password,
                Email = clientDto.Email
            };
            return _clientRepository.Add(Client);
        }

        public Client? GetById(int id)
        {
            return _clientRepository.GetById(id);
        }

        public List<Client> Get()
        {
            return _clientRepository.Get();
        }

        public void Remove(int id)
        {
            var client = _clientRepository.GetById(id);
            if (client is not null)
            {
                _clientRepository.Remove(client);
            }
        }



    }
    
}
