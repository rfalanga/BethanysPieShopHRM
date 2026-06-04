using BethanysPieShopHRM.Shared.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BethanysPieShopHRM.Components
{
    public partial class Map
    {
        string elementId = $"map-{Guid.NewGuid():D}";

        [Parameter]
        public double Zoom { get; set; }

        [Parameter]
        public List<Marker> Markers { get; set; } = new List<Marker>(); // Initialize to an empty list to avoid null reference issues; suggested by GitHub Copilot

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)    // Note: Gill do NOT have this conditional! He only had the await below, so I'm not sure this is correct.
            {
                await JSRuntime.InvokeVoidAsync("deliveryMap.showOrUpdate", elementId, Markers);    // deliveryMap is the name of the JavaScript object, and showOrUpdate is the name of the function in that object. elementId and Markers are the parameters being passed to that function.
            }
        }
    }
}
