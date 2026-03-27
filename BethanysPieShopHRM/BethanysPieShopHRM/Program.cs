using BethanysPieShopHRM.Components;
using BethanysPieShopHRM.Data;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseInMemoryDatabase("BethanysPieShopDb"));

var app = builder.Build();

// Seed the in-memory database with initial data
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!dbContext.Employees.Any())
    {
        dbContext.Countries.AddRange(
            new Country { CountryId = 1, Name = "Belgium" },
            new Country { CountryId = 2, Name = "Germany" },
            new Country { CountryId = 3, Name = "Netherlands" },
            new Country { CountryId = 4, Name = "USA" },
            new Country { CountryId = 5, Name = "Japan" },
            new Country { CountryId = 6, Name = "China" },
            new Country { CountryId = 7, Name = "UK" },
            new Country { CountryId = 8, Name = "France" },
            new Country { CountryId = 9, Name = "Brazil" }
        );

        dbContext.JobCategories.AddRange(
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

        dbContext.Employees.AddRange(
            new Employee
            {
                EmployeeId = 1,
                CountryId = 1, // Belgium
                Country = dbContext.Countries.FirstOrDefault(c => c.CountryId == 1),
                MaritalStatus = MaritalStatus.Single,
                BirthDate = new DateTime(1979, 1, 16),
                City = "Brussels",
                Email = "bethany@pieshop.com",
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
                Country = dbContext.Countries.FirstOrDefault(c => c.CountryId == 2),
                MaritalStatus = MaritalStatus.Married,
                BirthDate = new DateTime(1985, 6, 12),
                City = "Berlin",
                Email = "john@pieshop.com",
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
                Country = dbContext.Countries.FirstOrDefault(c => c.CountryId == 3),
                MaritalStatus = MaritalStatus.Single,
                BirthDate = new DateTime(1992, 3, 8),
                City = "Amsterdam",
                Email = "maria@pieshop.com",
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
                Country = dbContext.Countries.FirstOrDefault(c => c.CountryId == 4),
                MaritalStatus = MaritalStatus.Married,
                BirthDate = new DateTime(1980, 11, 30),
                City = "New York",
                Email = "james@pieshop.com",
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
                Country = dbContext.Countries.FirstOrDefault(c => c.CountryId == 8),
                MaritalStatus = MaritalStatus.Single,
                BirthDate = new DateTime(1995, 9, 14),
                City = "Paris",
                Email = "sophie@pieshop.com",
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
            }
        );

        dbContext.SaveChanges();
    }
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
