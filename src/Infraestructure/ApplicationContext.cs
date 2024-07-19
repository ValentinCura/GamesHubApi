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
        public DbSet<SaleDetail>? SaleDetails { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<SisAdmin>? SisAdmins { get; set; }

        

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
                  Rol = "SisAdmin"

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
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "GTA V",
                    Description = "Grand Theft Auto V is an action-adventure game played from either a third-person or first-person perspective. Players complete missions—linear scenarios with set objectives—to progress through the story. Outside of the missions, players may freely roam the open world.",
                    Type = "Action",
                    Price = 20,
                    Console = "PC"

                }
            );

            modelBuilder.Entity<User>().HasDiscriminator(u => u.Rol);

            modelBuilder.Entity<SaleDetail>()
                .HasOne(op => op.Product)
                .WithMany()
                .HasForeignKey(op => op.ProductId);
            modelBuilder.Entity<Review>()
                .HasOne(op => op.Product)
                .WithMany()
                .HasForeignKey(op => op.ProductId);
            modelBuilder.Entity<Review>()
               .HasOne(op => op.Client)
               .WithMany()
               .HasForeignKey(op => op.ClientId);
            modelBuilder.Entity<Sale>()
                .HasOne(op => op.Client)
                .WithMany()
                .HasForeignKey(op => op.ClientId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
