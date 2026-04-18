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
        public DbSet<TimeRegistration> TimeRegistrations { get; set; }

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
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                CountryId = 1, // Belgium
                MaritalStatus = MaritalStatus.Single,
                BirthDate = new DateTime(1979, 1, 16),
                City = "Brussels",
                Email = "bethany@bethanyspieshop.com",
                FirstName = "Bethany",
                LastName = "Smith",
                Gender = Gender.Female,
                PhoneNumber = "324777888773",
                Smoker = false,
                Street = "Grote Markt 1",
                Zip = "1000",
                JobCategoryId = 1, // Pie research
                Comment = "Founder of the Pie Shop.",
                ExitDate = null,
                JoinedDate = new DateTime(2015, 3, 1),
                Latitude = 50.8503,
                Longitude = 4.3517
            },
            new Employee
            {
                EmployeeId = 2,
                CountryId = 2, // Germany
                MaritalStatus = MaritalStatus.Married,
                BirthDate = new DateTime(1985, 6, 12),
                City = "Berlin",
                Email = "john@bethanyspieshop.com",
                FirstName = "John",
                LastName = "Doe",
                Gender = Gender.Male,
                PhoneNumber = "4930123456",
                Smoker = false,
                Street = "Unter den Linden 5",
                Zip = "10117",
                JobCategoryId = 2, // Sales
                Comment = "Sales manager for the DACH region.",
                ExitDate = null,
                JoinedDate = new DateTime(2020, 1, 15),
                Latitude = 52.5200,
                Longitude = 13.4050
            },
            new Employee
            {
                EmployeeId = 3,
                CountryId = 3, // Netherlands
                MaritalStatus = MaritalStatus.Single,
                BirthDate = new DateTime(1992, 3, 8),
                City = "Amsterdam",
                Email = "maria@bethanyspieshop.com",
                FirstName = "Maria",
                LastName = "Lopez",
                Gender = Gender.Female,
                PhoneNumber = "31201234567",
                Smoker = false,
                Street = "Nieuwestraat 10",
                Zip = "1012",
                JobCategoryId = 4, // Store staff
                Comment = "Works at the Amsterdam store.",
                ExitDate = null,
                JoinedDate = new DateTime(2021, 9, 1),
                Latitude = 52.3676,
                Longitude = 4.9041
            },
            new Employee
            {
                EmployeeId = 4,
                CountryId = 4, // USA
                MaritalStatus = MaritalStatus.Married,
                BirthDate = new DateTime(1980, 11, 30),
                City = "New York",
                Email = "james@bethanyspieshop.com",
                FirstName = "James",
                LastName = "Anderson",
                Gender = Gender.Male,
                PhoneNumber = "12125550123",
                Smoker = false,
                Street = "5th Avenue 123",
                Zip = "10001",
                JobCategoryId = 5, // Finance
                Comment = "Financial controller for US operations.",
                ExitDate = null,
                JoinedDate = new DateTime(2018, 5, 10),
                Latitude = 40.7128,
                Longitude = -74.0060
            },
            new Employee
            {
                EmployeeId = 5,
                CountryId = 8, // France
                MaritalStatus = MaritalStatus.Single,
                BirthDate = new DateTime(1995, 9, 14),
                City = "Paris",
                Email = "sophie@bethanyspieshop.com",
                FirstName = "Sophie",
                LastName = "Dubois",
                Gender = Gender.Female,
                PhoneNumber = "33123456789",
                Smoker = false,
                Street = "Champs-Élysées 55",
                Zip = "75008",
                JobCategoryId = 7, // IT
                Comment = "Part of the IT support team.",
                ExitDate = null,
                JoinedDate = new DateTime(2022, 2, 20),
                Latitude = 48.8566,
                Longitude = 2.3522
            });
        }
    }
}
