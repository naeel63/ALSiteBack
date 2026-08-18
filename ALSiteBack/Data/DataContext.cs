using ALSiteBack.Models;
using Microsoft.EntityFrameworkCore;

namespace ALSiteBack.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ActualDate> ActualDates { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Group> Groups { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>()
                .HasOne(item => item.Product)
                .WithMany()
                .HasForeignKey(item => item.ProductId);

            modelBuilder.Entity<Order>()
                .HasMany(order => order.Items)
                .WithOne(item => item.Order)
                .HasForeignKey(item => item.OrderId);

            modelBuilder.Entity<Group>()
                .HasMany(g => g.Children)
                .WithOne(g => g.Parent)
                .HasForeignKey(g => g.ParentId);
        }
    }
}