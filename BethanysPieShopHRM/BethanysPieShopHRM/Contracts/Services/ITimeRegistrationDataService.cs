using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Contracts.Services
{
    public interface ITimeRegistrationDataService
    {
        Task<List<TimeRegistration>> GetTimeRegistrationsForEmployeeAsync(int employeeId);
        Task<int> GetTimeRegistrationCountForEmployeeIdAsync(int employeeId);
        Task<List<TimeRegistration>> GetPageTimeRegistrationsForEmployeeIdAsync(int employeeId, int pageSize, int start);
    }
}