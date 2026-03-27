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
        public AppDbContext AppDbContext { get; set; }

        protected override void OnInitialized()
        {
            Employees = AppDbContext.Employees.ToList(); // This is how Gill did it
        }
    }
}
