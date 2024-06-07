using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Infraestructure.Data
{
    public class Context : DbContext
    {
        public DbSet<User> Users {  get; set; }
        DbSet<Admin> Admins { get; set; }
        DbSet<Client> Clients { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<Sale> Sales { get; set; }
        DbSet<SaleDetail> SaleDetails{ get; set; }
        
        public Context(DbContextOptions<Context> options) : base(options)
        {
            protected override void 
        }
    }
}
