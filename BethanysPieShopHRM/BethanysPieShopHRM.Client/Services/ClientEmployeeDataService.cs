using BethanysPieShopHRM.Shared.Domain;
using System.Text.Json;

namespace BethanysPieShopHRM.Client.Services
{
    public class ClientEmployeeDataService : IEmployeeDataService
    {
        private readonly HttpClient _httpClient;

        public ClientEmployeeDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Employee> AddEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployeeAsync(int employeeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            var list = await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>(
                await _httpClient.GetStreamAsync($"api/employee"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
            );
            return list;
        }

        public Task<Employee> GetEmployeeDetailsByIdAsync(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
