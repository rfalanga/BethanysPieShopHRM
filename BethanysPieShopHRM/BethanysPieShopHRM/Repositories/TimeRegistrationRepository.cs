using BethanysPieShopHRM.Contracts.Repositories;
using BethanysPieShopHRM.Data;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopHRM.Repositories
{
    public class TimeRegistrationRepository : ITimeRegistrationRepository, IDisposable
    {
        private readonly AppDbContext _dbContextFactory;

        public TimeRegistrationRepository(IDbContextFactory<AppDbContext> dbContextFactory) 
        {
            _dbContextFactory = dbContextFactory.CreateDbContext();
        }

        public async Task<List<TimeRegistration>> GetTimeRegistrationsForEmployeeAsync(int employeeId)
        {
            return await _dbContextFactory.TimeRegistrations.Where(testc => testc.EmployeeId == employeeId).OrderBy(tr => tr.StartTime).ToListAsync();
        }

        public void Dispose()
        {
            _dbContextFactory?.Dispose();
        }

        public async Task<List<TimeRegistration>> GetPagedTimeRegistrationsForEmployeeAsync(int employeeId, int pageSize, int start)
        {
            return await _dbContextFactory.TimeRegistrations
                .Where(testc => testc.EmployeeId == employeeId)
                .OrderBy(tr => tr.StartTime)
                .Skip(start)
                .Take(pageSize).ToListAsync();
        }

        public async Task<int> GetTimeRegistrationCountForEmployeeIdAsync(int employeeId)
        {
            return await _dbContextFactory.TimeRegistrations.Where(testc => testc.EmployeeId == employeeId).CountAsync();
        }
    }
}
