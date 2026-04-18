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
            throw new NotImplementedException();
        }
    }
}
