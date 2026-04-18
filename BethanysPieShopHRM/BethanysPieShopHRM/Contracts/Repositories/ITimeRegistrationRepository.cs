using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Contracts.Repositories
{
    public interface ITimeRegistrationRepository
    {
        Task<List<TimeRegistration>> GetTimeRegistrationsForEmployeeAsync(int employeeId);
    }
}