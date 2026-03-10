using Microsoft.EntityFrameworkCore;
using ECommerce.Domain.Entities;
namespace ECommerce_Infrastructure.Persistence
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().OwnsOne(c => c.Address);
            modelBuilder.Entity<Order>().OwnsOne(o => o.ShippingAddress);

            //Composite Primary Key 
            modelBuilder.Entity<OrderItem>().HasKey(oi => new { oi.OrderId, oi.ProductId });

            modelBuilder.Entity<Order>(builder =>
            {
                builder.OwnsOne(o => o.ShippingAddress, sa =>
                {
                    sa.Property(p => p.Street).HasColumnName("Street");
                    sa.Property(p => p.City).HasColumnName("City");
                    sa.Property(p => p.State).HasColumnName("State");
                    sa.Property(p => p.PostalCode).HasColumnName("PostalCode");
                    sa.Property(p => p.Country).HasColumnName("Country");
                });
            });

            modelBuilder.Entity<Customer>(builder =>
            {
                builder.OwnsOne(c => c.Address, a =>
                {
                    a.Property(p => p.Street).HasColumnName("Street");
                    a.Property(p => p.City).HasColumnName("City");
                    a.Property(p => p.State).HasColumnName("State");
                    a.Property(p => p.PostalCode).HasColumnName("PostalCode");
                    a.Property(p => p.Country).HasColumnName("Country");
                });
            });

            modelBuilder.Entity<Customer>().HasData(
                new { Id = 1, FirstName = "Saurabh", LastName = "Rout", Email = "saurabh@gmail.com", },
                new { Id = 2, FirstName = "Aniket", LastName = "Gabbar", Email = "aniket@gmail.com", }
                );

            modelBuilder.Entity<Customer>().OwnsOne(c => c.Address).HasData(
                new 
                { 
                    CustomerId = 1, 
                    Street = "Juni Vasti", 
                    City = "Badnera",
                    State = "Maharashtra",
                    PostalCode = "400400",
                    Country = "India"
                },
                new 
                { 
                    CustomerId = 2, 
                    Street = "Navi Akola", 
                    City = "Amravati",
                    State = "Maharashtra",
                    PostalCode = "400400",
                    Country = "India"
                });


            modelBuilder.Entity<Product>().HasData(
                new { Id = 1, Name = "Apple iPhone 17", Price = 89000m, StockQuantity = 50, Description = "A20 Bionic Chip" },
                new { Id = 2, Name = "Samsung A23", Price = 35000m, StockQuantity = 30, Description = "10x Zoom" },
                new { Id = 3, Name = "One Plus 15R", Price = 44000m, StockQuantity = 47, Description = "Oxygen OS" }
             );
        }  
    }
}
