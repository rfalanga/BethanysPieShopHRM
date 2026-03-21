using BethanysPieShopHRM.Data;
using BethanysPieShopHRM.Services;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.Components.Pages
{
    public partial class EmployeeDetail
    {
        [Parameter]
        public int EmployeeId { get; set; }

        [Inject]
        public AppDbContext AppDbContext { get; set; }  

        public Employee Employee { get; set; } = new Employee();

        protected async override void OnInitialized()
        {
            Employee = AppDbContext.Employees.Where(e => e.EmployeeId == EmployeeId).FirstOrDefault() ?? new Employee();
        }

        private void ChangeHolidayState()
        {
            Employee.IsOnHoliday = !Employee.IsOnHoliday;
        }
    }
}
