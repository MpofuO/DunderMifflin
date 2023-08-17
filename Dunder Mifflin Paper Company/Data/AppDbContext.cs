using Dunder_Mifflin_Paper_Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Dunder_Mifflin_Paper_Company.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Favourite> Favourites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductType>().ToTable("ProductType");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<CartProduct>().ToTable("CartProduct");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Favourite>().ToTable("Favourites");
        }
    }
}
