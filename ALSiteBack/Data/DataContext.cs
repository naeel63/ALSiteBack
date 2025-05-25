using ALSiteBack.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

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
    }
}
