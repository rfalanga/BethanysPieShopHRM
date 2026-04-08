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

            // seed countries
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 1, Name = "Belgium" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 2, Name = "Germany" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 3, Name = "Netherlands" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 4, Name = "USA" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 5, Name = "Japan" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 6, Name = "China" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 7, Name = "UK" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 8, Name = "France" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 9, Name = "Brazil" });

            // seed job categories
            modelBuilder.Entity<JobCategory>().HasData(
                new JobCategory { JobCategoryId = 1, JobCategoryName = "Pie research" },
                new JobCategory { JobCategoryId = 2, JobCategoryName = "Sales" },
                new JobCategory { JobCategoryId = 3, JobCategoryName = "Management" },
                new JobCategory { JobCategoryId = 4, JobCategoryName = "Store staff" },
                new JobCategory { JobCategoryId = 5, JobCategoryName = "Finance" },
                new JobCategory { JobCategoryId = 6, JobCategoryName = "QA" },
                new JobCategory { JobCategoryId = 7, JobCategoryName = "IT" },
                new JobCategory { JobCategoryId = 8, JobCategoryName = "Cleaning" },
                new JobCategory { JobCategoryId = 9, JobCategoryName = "Bakery" }
            );

            // seed employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    CountryId = 1,
                    FirstName = "Bethany",
                    LastName = "Smith",
                    Email = "bethany@bethanyspieshop.com",
                    JobCategoryId = 1,
                    JoinedDate = new DateTime(2015, 3, 1)
                },
                new Employee
                {
                    EmployeeId = 2,
                    CountryId = 2,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john@bethanyspieshop.com",
                    JobCategoryId = 2,
                    JoinedDate = new DateTime(2020, 1, 15)
                }
            );
        }
    }
}
