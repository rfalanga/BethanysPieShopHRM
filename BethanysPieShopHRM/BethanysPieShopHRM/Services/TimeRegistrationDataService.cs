using BethanysPieShopHRM.Contracts.Repositories;
using BethanysPieShopHRM.Contracts.Services;
using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Services
{
    public class TimeRegistrationDataService : ITimeRegistrationDataService
    {
        private readonly ITimeRegistrationRepository _timeRegistrationRepository;

        public TimeRegistrationDataService(ITimeRegistrationRepository timeRegistrationRepository) 
        {
            _timeRegistrationRepository = timeRegistrationRepository;
        }

        public async Task<List<TimeRegistration>> GetTimeRegistrationsForEmployeeAsync(int employeeId)
        {
            return await _timeRegistrationRepository.GetTimeRegistrationsForEmployeeAsync(employeeId);
        }
    }
}
