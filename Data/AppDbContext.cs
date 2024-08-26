using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkloadApp.Models;

namespace WorkloadApp.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City_Service>().HasKey(cs => new
            {
                cs.ServiceId,
                cs.CityId
            });

            modelBuilder.Entity<City_Service>().HasOne(s => s.Service).WithMany(cs => cs.Cities_Services).HasForeignKey(s => s.ServiceId);
            modelBuilder.Entity<City_Service>().HasOne(s => s.City).WithMany(cs => cs.Cities_Services).HasForeignKey(s => s.CityId);

            base.OnModelCreating(modelBuilder);
        }

        //public DbSet<User> Users { get; set; }
        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<City_Service> Cities_Services { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
