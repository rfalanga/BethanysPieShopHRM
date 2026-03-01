using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Services
{
    public class MockDataService
    {
        private static List<Employee>? _employees = default!;
        private static List<JobCategory> _jobCategories = default!;
        private static List<Country> _countries = default!;

        public static List<Employee>? Employees
        {
            get
            {
                _countries ??= InitializeMockCountries();
                _jobCategories ??= InitializeMockJobCategories();
                _employees ??= InitializeMockEmployees();
                return _employees;
            }
        }

        private static List<Employee> InitializeMockEmployees()
        {
            var e1 = new Employee
            {
                MaritalStatus = MaritalStatus.Single,
                BirthDate = new DateTime(1989, 3, 11),
                City = "Brussels",
                Email = "bethany@bethanyspieshop.com",
                EmployeeId = 1,
                FirstName = "Bethany",
                LastName = "Smith",
                Gender = Gender.Female,
                PhoneNumber = "324777888773",
                Smoker = false,
                Street = "Grote Markt 1",
                Zip = "1000",
                JobCategory = _jobCategories[2],
                JobCategoryId = _jobCategories[2].JobCategoryId,
                Comment = "Lorem Ipsum",
                ExitDate = null,
                JoinedDate = new DateTime(2015, 3, 1),
                Country = _countries[0],
                CountryId = _countries[0].CountryId,
                IsOnHoliday = false
            };

            var e2 = new Employee
            {
                MaritalStatus = MaritalStatus.Married,
                BirthDate = new DateTime(1979, 1, 16),
                City = "Antwerp",
                Email = "gill@bethanyspieshop.com",
                EmployeeId = 2,
                FirstName = "Gill",
                LastName = "Cleeren",
                Gender = Gender.Female,
                PhoneNumber = "33999909923",
                Smoker = false,
                Street = "New Street",
                Zip = "2000",
                JobCategory = _jobCategories[1],
                JobCategoryId = _jobCategories[1].JobCategoryId,
                Comment = "Lorem Ipsum",
                ExitDate = null,
                JoinedDate = new DateTime(2017, 12, 24),
                Country = _countries[1],
                CountryId = _countries[1].CountryId,
                IsOnHoliday = false
            };

            var e3 = new Employee
            {
                MaritalStatus = MaritalStatus.Single,
                BirthDate = new DateTime(1990, 6, 5),
                City = "Amsterdam",
                Email = "john@bethanyspieshop.com",
                EmployeeId = 3,
                FirstName = "John",
                LastName = "Doe",
                Gender = Gender.Male,
                PhoneNumber = "31012345678",
                Smoker = true,
                Street = "Canal Street",
                Zip = "1012",
                JobCategory = _jobCategories[0],
                JobCategoryId = _jobCategories[0].JobCategoryId,
                Comment = "Research specialist",
                ExitDate = null,
                JoinedDate = new DateTime(2018, 5, 15),
                Country = _countries[1],
                CountryId = _countries[1].CountryId,
                IsOnHoliday = false
            };

            var e4 = new Employee
            {
                MaritalStatus = MaritalStatus.Married,
                BirthDate = new DateTime(1985, 9, 20),
                City = "New York",
                Email = "mary@bethanyspieshop.com",
                EmployeeId = 4,
                FirstName = "Mary",
                LastName = "Johnson",
                Gender = Gender.Female,
                PhoneNumber = "12125551234",
                Smoker = false,
                Street = "5th Avenue",
                Zip = "10001",
                JobCategory = _jobCategories[4],
                JobCategoryId = _jobCategories[4].JobCategoryId,
                Comment = "Finance manager",
                ExitDate = null,
                JoinedDate = new DateTime(2016, 8, 10),
                Country = _countries[2],
                CountryId = _countries[2].CountryId,
                IsOnHoliday = false
            };

            var e5 = new Employee
            {
                MaritalStatus = MaritalStatus.Single,
                BirthDate = new DateTime(1992, 12, 2),
                City = "Tokyo",
                Email = "hiro@bethanyspieshop.com",
                EmployeeId = 5,
                FirstName = "Hiroshi",
                LastName = "Tanaka",
                Gender = Gender.Male,
                PhoneNumber = "81312345678",
                Smoker = false,
                Street = "Shinjuku Street",
                Zip = "160-0022",
                JobCategory = _jobCategories[6],
                JobCategoryId = _jobCategories[6].JobCategoryId,
                Comment = "IT developer",
                ExitDate = null,
                JoinedDate = new DateTime(2020, 1, 5),
                Country = _countries[3],
                CountryId = _countries[3].CountryId,
                IsOnHoliday = true
            };

            var e6 = new Employee
            {
                MaritalStatus = MaritalStatus.Married,
                BirthDate = new DateTime(1982, 7, 30),
                City = "Beijing",
                Email = "li@bethanyspieshop.com",
                EmployeeId = 6,
                FirstName = "Li",
                LastName = "Wei",
                Gender = Gender.Male,
                PhoneNumber = "861012345678",
                Smoker = false,
                Street = "Chang’an Avenue",
                Zip = "100006",
                JobCategory = _jobCategories[5],
                JobCategoryId = _jobCategories[5].JobCategoryId,
                Comment = "QA engineer",
                ExitDate = null,
                JoinedDate = new DateTime(2019, 11, 1),
                Country = _countries[4],
                CountryId = _countries[4].CountryId,
                IsOnHoliday = false
            };

            var e7 = new Employee
            {
                MaritalStatus = MaritalStatus.Single,
                BirthDate = new DateTime(1995, 4, 14),
                City = "London",
                Email = "sophie@bethanyspieshop.com",
                EmployeeId = 7,
                FirstName = "Sophie",
                LastName = "Brown",
                Gender = Gender.Female,
                PhoneNumber = "447911123456",
                Smoker = false,
                Street = "Oxford Street",
                Zip = "W1D",
                JobCategory = _jobCategories[3],
                JobCategoryId = _jobCategories[3].JobCategoryId,
                Comment = "Store staff member",
                ExitDate = null,
                JoinedDate = new DateTime(2021, 9, 1),
                Country = _countries[5],
                CountryId = _countries[5].CountryId,
                IsOnHoliday = false
            };

            var e8 = new Employee
            {
                MaritalStatus = MaritalStatus.Married,
                BirthDate = new DateTime(1987, 11, 9),
                City = "Paris",
                Email = "pierre@bethanyspieshop.com",
                EmployeeId = 8,
                FirstName = "Pierre",
                LastName = "Dubois",
                Gender = Gender.Male,
                PhoneNumber = "33123456789",
                Smoker = true,
                Street = "Rue de Rivoli",
                Zip = "75001",
                JobCategory = _jobCategories[8],
                JobCategoryId = _jobCategories[8].JobCategoryId,
                Comment = "Master baker",
                ExitDate = null,
                JoinedDate = new DateTime(2014, 6, 1),
                Country = _countries[6],
                CountryId = _countries[6].CountryId,
                IsOnHoliday = false
            };

            return new List<Employee> { e1, e2, e3, e4, e5, e6, e7, e8 };
        }

        private static List<JobCategory> InitializeMockJobCategories() => [
            new JobCategory{JobCategoryId = 1, JobCategoryName = "Pie research"},
            new JobCategory{JobCategoryId = 2, JobCategoryName = "Sales"},
            new JobCategory{JobCategoryId = 3, JobCategoryName = "Management"},
            new JobCategory{JobCategoryId = 4, JobCategoryName = "Store staff"},
            new JobCategory{JobCategoryId = 5, JobCategoryName = "Finance"},
            new JobCategory{JobCategoryId = 6, JobCategoryName = "QA"},
            new JobCategory{JobCategoryId = 7, JobCategoryName = "IT"},
            new JobCategory{JobCategoryId = 8, JobCategoryName = "Cleaning"},
            new JobCategory{JobCategoryId = 9, JobCategoryName = "Bakery"}
        ];

        private static List<Country> InitializeMockCountries() => [
            new Country {CountryId = 1, Name = "Belgium"},
            new Country {CountryId = 2, Name = "Netherlands"},
            new Country {CountryId = 3, Name = "USA"},
            new Country {CountryId = 4, Name = "Japan"},
            new Country {CountryId = 5, Name = "China"},
            new Country {CountryId = 6, Name = "UK"},
            new Country {CountryId = 7, Name = "France"},
            new Country {CountryId = 8, Name = "Brazil"}
        ];
    }
}
