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
            modelBuilder.Entity<Client>().HasData(
               new Client
               {
                   Id = 4,
                   Name = "Mauro",
                   LastName = "Brizio",
                   Username = "mauroBrizio",
                   Password = "mauro123",
                   Email = "maurobrizio@gmail.com",
                   Rol = "Client"

               }
           );
           modelBuilder.Entity<Client>().HasData(
               new Client
               {
                   Id = 5,
                   Name = "Matias",
                   LastName = "Danunzio",
                   Username = "matiasDanunzio",
                   Password = "matias123",
                   Email = "matiasdanunzio@gmail.com",
                   Rol = "Client"

               }
           );
           modelBuilder.Entity<Client>().HasData(
               new Client
               {
                   Id = 6,
                   Name = "Mateo",
                   LastName = "Caranta",
                   Username = "mateoCaranta",
                   Password = "mateo123",
                   Email = "mateocaranta@gmail.com",
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
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 2,
                    Name = "EA FC 24",
                    Description = "The most true-to-football experience ever, with HyperMotionV, PlayStyles optimized by Opta, and a revolutionized Frostbite™ Engine that reinvents how over 19,000 authentic players move, play, and look in every match.",
                    Type = "Sport",
                    Price = 30,
                    Console = "PS5"

                }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 3,
                    Name = "MORTAL KOMBAT",
                    Description = "Popular fighting video game franchise known for its brutal combat, iconic characters, and distinctive fatalities. Created by Ed Boon and John Tobias, it was first released by Midway Games in 1992. The game features a diverse roster of fighters, each with unique abilities and special moves. Players compete in one-on-one battles in a tournament setting, with the ultimate goal of defeating the final boss and becoming the champion.",
                    Type = "FIGHT",
                    Price = 30,
                    Console = "PS5"

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
