using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistance.Entities;
using Persistance.Entities.Configuration;
using System.Text.Json;
namespace Persistance
{
    public class ApplicationDbContext : DbContext
    {
       public DbSet<User> Users { get; set; }
       public DbSet<UserProfile> UserProfiles { get; set; }
       public DbSet <Product> Products { get; set; }
       public DbSet<Category> Categories { get; set; }
       public DbSet<Brand> Brands { get; set; }
       public DbSet<Shop> Shops { get; set; }
       public DbSet<Tariff> Tariffs { get; set; }
       public DbSet<TariffDescription> TariffDescriptions { get; set; }

       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=0501");
       }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserProfileConfiguration());  
       }
    }
}
