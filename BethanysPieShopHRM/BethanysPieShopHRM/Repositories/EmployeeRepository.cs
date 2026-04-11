using BethanysPieShopHRM.Contracts.Repositories;
using BethanysPieShopHRM.Data;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopHRM.Repositories
{
    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {
        private readonly AppDbContext appDbContext;

        public EmployeeRepository(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            appDbContext = dbContextFactory.CreateDbContext();
        }

        public void Dispose()
        {
            appDbContext.Dispose();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await appDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            return await appDbContext.Employees.FirstOrDefaultAsync(c => c.EmployeeId == employeeId);
        }
    }
}
