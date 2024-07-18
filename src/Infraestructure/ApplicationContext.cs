using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public class ApplicationContext : DbContext
    {


        public DbSet<Admin>? Admins { get; set; }
        public DbSet<Client>? Clients { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Review>? Reviews { get; set; }
        public DbSet<Sale>? Sales { get; set; }
        public DbSet<SaleDetail>? SaleDetail { get; set; }
        public DbSet<User>? Users { get; set; }

        

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator(u => u.Rol);

            modelBuilder.Entity<SisAdmin>().HasData(
              new SisAdmin
              {
                  Id = 1,
                  Name = "Raul",
                  LastName = "Gonzales",
                  Username = "sisAdmin",
                  Password = "sisadmin123",
                  Email = "sisadmin@gmail.com",
                  Rol = "sisAdmin"

              });

            modelBuilder.Entity<Admin>().HasData(new Admin
            {
                Id = 2,
                Name = "Juan",
                LastName = "Perez",
                Username = "juanPerez",
                Password = "juan123",
                Email = "JuanPerez@gmail.com",
                Rol = "Admin"
            });
           
           modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    Id = 3,
                    Name = "Valentin",
                    LastName = "Cura",
                    Username = "valenCura",
                    Password = "valen123",
                    Email = "valencura@gmail.com",
                    Rol = "Client"

                }
            );

            modelBuilder.Entity<User>().HasDiscriminator(u => u.Rol);

            modelBuilder.Entity<SaleDetail>()
                .HasOne(op => op.Product)
                .WithMany()
                .HasForeignKey(op => op.ProductId);
            modelBuilder.Entity<SaleDetail>()
                .HasOne(op => op.Sale)
                .WithMany(p => p.SaleDetails)
                .HasForeignKey(op => op.SaleId);
            modelBuilder.Entity<Review>()
                .HasOne(op => op.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(op => op.ProductId);
            modelBuilder.Entity<Review>()
               .HasOne(op => op.Client)
               .WithMany(p => p.Reviews)
               .HasForeignKey(op => op.ClientId);
            modelBuilder.Entity<Sale>()
                .HasOne(op => op.Client)
                .WithMany(p => p.Buys)
                .HasForeignKey(op => op.ClientId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
