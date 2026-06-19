//using BethanysPieShopHRM.Client;
using BethanysPieShopHRM.Contracts.Services;
using BethanysPieShopHRM.Data;
using BethanysPieShopHRM.Services;
using BethanysPieShopHRM.Shared.Domain;
using BethanysPieShopHRM.Shared.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;
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

        protected IQueryable<TimeRegistration>? itemsQueryable { get; set; } 

        public List<TimeRegistration> TimeRegistrations { get; set; } = [];

        public List<Marker> MapMarkers { get; set; } = [];

        private float itemHeight = 50;

        protected int queryableCount = 0;

        public PaginationState pagination = new() { ItemsPerPage = 10 };

        protected override async Task OnInitializedAsync()
        {
            Employee = await EmployeeDataService.GetEmployeeDetailsByIdAsync(EmployeeId);
            TimeRegistrations = await TimeRegistrationDataService.GetTimeRegistrationsForEmployeeAsync(EmployeeId);
            itemsQueryable = (await TimeRegistrationDataService.GetTimeRegistrationsForEmployeeAsync(EmployeeId)).AsQueryable();
            queryableCount = itemsQueryable.Count();

            if (Employee.Longitude.HasValue && Employee.Latitude.HasValue)
            {
                MapMarkers = new List<Marker>
                {
                    new Marker { Description = $"{Employee.FirstName} {Employee.LastName}", ShowPopup = false, X = Employee.Latitude.Value, Y = Employee.Longitude.Value }
                };
            }
        }

        private void ChangeHolidayState()
        {
            Employee.IsOnHoliday = !Employee.IsOnHoliday;
        }

        public async ValueTask<ItemsProviderResult<TimeRegistration>> LoadTimeRegistrations(ItemsProviderRequest itemsProviderRequest)
        { 
            int totalNumberOfTimeRegistrations = await TimeRegistrationDataService.GetTimeRegistrationCountForEmployeeIdAsync(EmployeeId);

            var numberOfTimeRegistrations = Math.Min(itemsProviderRequest.Count, totalNumberOfTimeRegistrations - itemsProviderRequest.StartIndex);

            var listItems = await TimeRegistrationDataService.GetPageTimeRegistrationsForEmployeeIdAsync(EmployeeId, itemsProviderRequest.StartIndex, numberOfTimeRegistrations);
            
            return new ItemsProviderResult<TimeRegistration>(listItems, totalNumberOfTimeRegistrations);
        }
    }
}
