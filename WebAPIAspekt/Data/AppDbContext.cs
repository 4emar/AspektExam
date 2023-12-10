using Microsoft.EntityFrameworkCore;
using WebAPIAspekt.Models;

namespace WebAPIAspekt.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasKey(c => c.CompanyId);
            modelBuilder.Entity<Country>().HasKey(c => c.CountryId);
            modelBuilder.Entity<Contact>().HasKey(c => c.ContactId);
        }
    }
}
