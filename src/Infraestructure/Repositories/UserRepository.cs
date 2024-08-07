﻿using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
        public User? GetByUsername(string username )
        {
            return _context.Users.FirstOrDefault(p => p.Username == username);
        }
    }
}
