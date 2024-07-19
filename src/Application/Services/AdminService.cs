using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService (IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public Admin Add(AdminForRequest adminDto)
        {
            var Admin = new Admin()
            {
                Name = adminDto.Name,
                LastName = adminDto.LastName,
                Username = adminDto.Username,
                Password = adminDto.Password,
                Email = adminDto.Email,
                Rol = "Admin"
            };
            return _adminRepository.Add(Admin);
        }

        public Admin? GetById(int id)
        {
            return _adminRepository.GetById(id);
        }

        public List<Admin> Get() 
        {
            return _adminRepository.Get();
        }

        public void Remove(int id)
        {
            var admin = _adminRepository.GetById(id);
            if (admin is not null)
            {
                _adminRepository.Remove(admin);
            }
        }
    }
}
