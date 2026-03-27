using BethanysPieShopHRM.Data;
using BethanysPieShopHRM.Services;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopHRM.Components.Pages
{
    public partial class EmployeeDetail
    {
        [Parameter]
        public int EmployeeId { get; set; }

        [Inject]
        public AppDbContext AppDbContext { get; set; } = default!;

        public Employee Employee { get; set; } = new Employee();

        // I got rid of the child branch too quickly, so I'm putting this comment in to create a new branch.
        protected override async Task OnInitializedAsync()
        {
            Employee = await AppDbContext.Employees
                .Include(e => e.Country)
                .FirstOrDefaultAsync(e => e.EmployeeId == EmployeeId) ?? new Employee();
        }

        private void ChangeHolidayState()
        {
            Employee.IsOnHoliday = !Employee.IsOnHoliday;
        }
    }
}
