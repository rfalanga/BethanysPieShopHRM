using BethanysPieShopHRM.Contracts.Services;
using BethanysPieShopHRM.Data;
using BethanysPieShopHRM.Services;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.Components.Pages
{
    public partial class EmployeeOverview
    {
        public List<Employee> Employees { get; set; } = default!;

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        private string Title = "Employee Overview";

        // Gill pointed out that instead of using the Inject above, we could have used constructor injection like this:
        //public EmployeeOverview(AppDbContext appDbContext)
        //{
        //    AppDbContext = appDbContext;
        //}
        // However, I'll leave the inject in place.

        private Employee? _selectedEmployee;

        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeDataService.GetAllEmployeesAsync()).ToList();
        }

        public void ShowQuickViewPopup(Employee selectedEmployee)
        {
            _selectedEmployee = selectedEmployee;
        }
    }
}
