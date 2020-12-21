using Microsoft.AspNetCore.Components;

namespace BlazorApp.Web.Pages
{
    public class ReplayBase : ComponentBase
    {
        [Parameter]
        public TicketDetailDto TicketDetailDto { get; set; }


    }
}
