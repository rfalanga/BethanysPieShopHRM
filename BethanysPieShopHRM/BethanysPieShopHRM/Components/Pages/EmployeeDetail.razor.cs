using BethanysPieShopHRM.Contracts.Services;
using BethanysPieShopHRM.Data;
using BethanysPieShopHRM.Services;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace BethanysPieShopHRM.Components.Pages
{
    public partial class EmployeeDetail
    {
        [Parameter]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; } = new Employee();

        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; }

        [Inject]
        public ITimeRegistrationDataService? TimeRegistrationDataService { get; set; }

        public List<TimeRegistration> TimeRegistrations { get; set; } = [];

        protected override async Task OnInitializedAsync()
        {
            Employee = await EmployeeDataService.GetEmployeeDetailsByIdAsync(EmployeeId);
            TimeRegistrations = await TimeRegistrationDataService.GetTimeRegistrationsForEmployeeAsync(EmployeeId);
        }

        private void ChangeHolidayState()
        {
            Employee.IsOnHoliday = !Employee.IsOnHoliday;
        }

        public async ValueTask<ItemsProviderResult<TimeRegistration>> LoadTimeRegistrations(ItemsProviderRequest itemsProviderRequest)
        { 
            int totalNumberOfTimeRegistrations = await TimeRegistrationDataService.GetTimeRegistrationCountForEmployeeAsync(EmployeeId);

            var numberOfTimeRegistrations = Math.Min(itemsProviderRequest.Count, totalNumberOfTimeRegistrations - itemsProviderRequest.StartIndex);

            var listItems = await TimeRegistrationDataService.GetPageTimeRegistrationsForEmployeeIdAsync(EmployeeId, itemsProviderRequest.StartIndex, numberOfTimeRegistrations);
            
            return new ItemsProviderResult<TimeRegistration>(listItems, totalNumberOfTimeRegistrations);
        }
    }
}
