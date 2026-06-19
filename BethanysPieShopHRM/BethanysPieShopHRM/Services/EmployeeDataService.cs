using BethanysPieShopHRM.Contracts.Repositories;
using BethanysPieShopHRM.Contracts.Services;
using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHttpContextAccessor _httpContextAccessor; // suggested by GitHub Copilot, and Gill added this later
        private readonly IWebHostEnvironment _webHostEnvironment;   // suggested by GitHub Copilot, and Gill added this later

        public EmployeeDataService(IEmployeeRepository employeeRepository, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment)
        {
            _employeeRepository = employeeRepository;
            _httpContextAccessor = httpContextAccessor;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllEmployeesAsync();
        }

        public async Task<Employee> GetEmployeeDetailsByIdAsync(int employeeId)
        {
            return await _employeeRepository.GetEmployeeDetailsByIdAsync(employeeId);
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            return await _employeeRepository.AddEmployeeAsync(employee);
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            if (employee.ImageContent != null)
            {
                string currentUrl = _httpContextAccessor.HttpContext.Request.Host.Value;
                var path = $"{_webHostEnvironment.WebRootPath}\\uploads\\{employee.ImageName}";
                var fileStream = System.IO.File.Create(path);
                fileStream.Write(employee.ImageContent, 0, employee.ImageContent.Length);
                fileStream.Close();

                employee.ImageName = $"http://{currentUrl}/uploads/{employee.ImageName}";
            }

            return await _employeeRepository.UpdateEmployeeAsync(employee);
        }

        public async Task DeleteEmployeeAsync(int employeeId)
        {
            await _employeeRepository.DeleteEmployeeAsync(employeeId);
        } 
    }
}
