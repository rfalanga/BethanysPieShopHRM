using BethanysPieShopHRM.Client;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.Components.Pages
{
    public partial class EmployeeAdd
    {
        [SupplyParameterFromForm]
        public Employee Employee { get; set; }

        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; }

        protected string Message { get; set; } = string.Empty;
        protected bool IsSaved { get; set; } = false;

        protected override void OnInitialized()
        {
            Employee ??= new();
        }

        private async Task OnSubmit()
        {
            if (EmployeeDataService != null)
            {
                _ = await EmployeeDataService.AddEmployeeAsync(Employee);

                IsSaved = true;
                Message = $"Employee {Employee.FirstName} {Employee.LastName} was added successfully.";
            }
        }

    }
}
