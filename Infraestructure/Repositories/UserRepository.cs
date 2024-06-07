using Domain.Entities;
using Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class UserRepository
    {   
        private readonly Context _context;
        public UserRepository(Context context)
        {
            _context = context;
        }
        public User Get(string name)
        {
            return _context.Users.FirstOrDefault(u => u.Name == name);
        }
    }
}
