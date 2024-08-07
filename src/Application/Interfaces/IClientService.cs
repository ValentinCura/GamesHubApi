﻿using Application.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClientService
    {
        Client Add(ClientForRequest clientDto);
        Client? GetById(int id);
        List<Client> Get();
        void Remove(int id);
        int UpdatePassword(int clientId, string password);
    }
}
