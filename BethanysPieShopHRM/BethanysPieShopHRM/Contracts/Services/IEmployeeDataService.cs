using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Contracts.Services
{
    public interface IEmployeeDataService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeDetailsByIdAsync(int employeeId);
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int employeeId);

    }
}
