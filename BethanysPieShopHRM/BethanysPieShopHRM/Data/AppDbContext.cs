using BethanysPieShopHRM.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopHRM.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seed data for Countries
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 1, Name = "United States" },
                new Country { CountryId = 2, Name = "Canada" },
                new Country { CountryId = 3, Name = "United Kingdom" }
            );
            // Seed data for JobCategories
            modelBuilder.Entity<JobCategory>().HasData(
                new JobCategory { JobCategoryId = 1, JobCategoryName = "Management" },
                new JobCategory { JobCategoryId = 2, JobCategoryName = "Sales" },
                new JobCategory { JobCategoryId = 3, JobCategoryName = "IT" }
            );
        }
    }
}
