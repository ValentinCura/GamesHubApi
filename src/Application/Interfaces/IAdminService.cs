using Application.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAdminService
    {
        Admin Add(AdminForRequest adminDto);
        Admin? GetById(int id);
        List<Admin> Get();
        void Remove(int id);
        int UpdateUsername(int adminId, string username);
    }
}
