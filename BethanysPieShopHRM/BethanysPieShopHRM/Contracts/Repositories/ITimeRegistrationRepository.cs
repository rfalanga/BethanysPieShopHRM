using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Contracts.Repositories
{
    public interface ITimeRegistrationRepository
    {
        Task<List<TimeRegistration>> GetTimeRegistrationsForEmployeeAsync(int employeeId);
        Task<List<TimeRegistration>> GetPagedTimeRegistrationsForEmployeeAsync(int employeeId, DateTime startDate, DateTime endDate);
        Task<int> GetTimeRegistrationCountForEmployeeIdAsync(int employeeId);
    }
}