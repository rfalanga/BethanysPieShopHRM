using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Contracts.Services
{
    public interface IEmployeeDataService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeDetailsByIdAsync(int employeeId); // I changed the name of this method to be more descriptive
    }
}
