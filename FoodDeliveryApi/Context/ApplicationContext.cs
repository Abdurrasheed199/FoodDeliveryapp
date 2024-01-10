using FoodDeliveryApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace FoodDeliveryApi.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options /*IIdentityService identityService*/) : base(options)
        {
            //_identityService = identityService;

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string userId = Guid.NewGuid().ToString();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = userId,
                FirstName = "",
                LastName = "Temidayo",
                Email = "raufroqeeb123@gmail.com",
                IsDeleted = false,
                IsEmailConfirmed = true,
                Username = "Ayo",
                Password = "Ayo123",

            });
            string adminId = Guid.NewGuid().ToString();
            modelBuilder.Entity<Admin>().HasData(new Admin
            {
                Id = adminId,
                UserId = userId,
                FirstName = "Roqeeb",
                LastName = "Temidayo",
                Age = 20,
                Email = "raufroqeeb123@gmail.com",
                IsDeleted = false,

            });
            string roleId = Guid.NewGuid().ToString();
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = roleId,
                Name = "Admin",
                IsDeleted = false
            });
            string userRoleId = Guid.NewGuid().ToString();
            modelBuilder.Entity<UserRole>().HasData(new UserRole
            {
                Id = userRoleId,
                UserId = userId,
                RoleId = roleId,
                IsDeleted = false
            });
           
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        //public DbSet<Product> Products { get; set; }
        public DbSet<ProductCart> ProductCarts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }

    }
}
