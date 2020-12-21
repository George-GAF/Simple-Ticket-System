using Microsoft.AspNetCore.Components;


namespace BlazorApp.Web.Pages
{
    public class FilterBarBase : ComponentBase
    {
        [Parameter]
        public EventCallback<bool> ShowNewTicket { get; set; }
        
        [Parameter]
        public bool ShowItem { get; set; } 
        

        protected override System.Threading.Tasks.Task OnInitializedAsync()
        {
           
            return base.OnInitializedAsync();
        }
        public void MakingNewTicket()
        {
            ShowNewTicket.InvokeAsync(true);
        }

        protected void Close()
        {
            ShowNewTicket.InvokeAsync(false);
        }
    }
}
