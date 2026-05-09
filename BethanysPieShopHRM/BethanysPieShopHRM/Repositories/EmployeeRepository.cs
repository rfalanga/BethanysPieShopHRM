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

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            var addedEmployee = await appDbContext.Employees.AddAsync(employee);
            await appDbContext.SaveChangesAsync();
            return addedEmployee.Entity;
        }

        public async Task DeleteEmployeeAsync(int employeeId)
        {
            var employeeToDelete = await appDbContext.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (employeeToDelete == null) return;

            appDbContext.Employees.Remove(employeeToDelete);
            await appDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            appDbContext.Dispose();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await appDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeDetailsByIdAsync(int employeeId)
        {
            return await appDbContext.Employees.Include(e => e.Country).FirstOrDefaultAsync(c => c.EmployeeId == employeeId);
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            var employeeToUpdate = await appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

            // This logic is what GitHub Copilot suggested, which is significantly shorter than Gill's code. I don't know if it is correct,
            // so will test it.
            if (employeeToUpdate != null)   
            {
                appDbContext.Entry(employeeToUpdate).CurrentValues.SetValues(employee);
                await appDbContext.SaveChangesAsync();
            }
            return employeeToUpdate;
        }
    }
}
