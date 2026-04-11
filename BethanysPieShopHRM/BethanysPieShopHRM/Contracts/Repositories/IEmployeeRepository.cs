using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Contracts.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeDetailsByIdAsync(int employeeId);
    }
}
