using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.Components
{
    public partial class EmployeeCard
    {
        [Parameter]
        public Employee Employee { get; set; } = default!;

        [Parameter]
        public EventCallback<Employee> EmployeeQuickViewClicked { get; set; }

        protected override void OnInitialized()
        {
            if (Employee.FirstName == "Bethany")
            {
                // Gill is doing this to illustrate adding an error boundary
                throw new Exception("Error with first name");
            }
        }
    }
}
