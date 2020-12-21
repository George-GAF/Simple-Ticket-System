// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorApp.Web.Pages
{
    #line hidden
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "E:\tempery files\BlazorApp.Web\BlazorApp.Web\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\tempery files\BlazorApp.Web\BlazorApp.Web\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\tempery files\BlazorApp.Web\BlazorApp.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\tempery files\BlazorApp.Web\BlazorApp.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\tempery files\BlazorApp.Web\BlazorApp.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\tempery files\BlazorApp.Web\BlazorApp.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\tempery files\BlazorApp.Web\BlazorApp.Web\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\tempery files\BlazorApp.Web\BlazorApp.Web\_Imports.razor"
using BlazorApp.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\tempery files\BlazorApp.Web\BlazorApp.Web\_Imports.razor"
using BlazorApp.Web.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "E:\tempery files\BlazorApp.Web\BlazorApp.Web\_Imports.razor"
using Syncfusion.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "E:\tempery files\BlazorApp.Web\BlazorApp.Web\_Imports.razor"
using Syncfusion.Blazor.Grids;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "E:\tempery files\BlazorApp.Web\BlazorApp.Web\_Imports.razor"
using Syncfusion.Blazor.Navigations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "E:\tempery files\BlazorApp.Web\BlazorApp.Web\_Imports.razor"
using Syncfusion.Blazor.Cards;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "E:\tempery files\BlazorApp.Web\BlazorApp.Web\_Imports.razor"
using Syncfusion.Blazor.RichTextEditor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "E:\tempery files\BlazorApp.Web\BlazorApp.Web\_Imports.razor"
using Syncfusion.Blazor.Buttons;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "E:\tempery files\BlazorApp.Web\BlazorApp.Web\_Imports.razor"
using Syncfusion.Blazor.DropDowns;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "E:\tempery files\BlazorApp.Web\BlazorApp.Web\_Imports.razor"
using Syncfusion.Blazor.Inputs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "E:\tempery files\BlazorApp.Web\BlazorApp.Web\_Imports.razor"
using DevExpress.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "E:\tempery files\BlazorApp.Web\BlazorApp.Web\_Imports.razor"
using DevExpress.Blazor.FormLayout.Internal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "E:\tempery files\BlazorApp.Web\BlazorApp.Web\_Imports.razor"
using DevExpress.Blazor.FormLayout;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "E:\tempery files\BlazorApp.Web\BlazorApp.Web\_Imports.razor"
using DevExpress.Blazor.Configuration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "E:\tempery files\BlazorApp.Web\BlazorApp.Web\Pages\MainView.razor"
using System.Collections.Generic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "E:\tempery files\BlazorApp.Web\BlazorApp.Web\Pages\MainView.razor"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "E:\tempery files\BlazorApp.Web\BlazorApp.Web\Pages\MainView.razor"
using System.IO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "E:\tempery files\BlazorApp.Web\BlazorApp.Web\Pages\MainView.razor"
using System.Linq;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class MainView : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 51 "E:\tempery files\BlazorApp.Web\BlazorApp.Web\Pages\MainView.razor"
      

    protected bool isOpenTicket { get; set; } = false;

    protected bool isNewTic { get; set; } = false;

    protected TicketDto ticketDto { get; set; }

    protected bool[] colVis { get; set; }

    public User CurrentUser { get; set; }

    public List<TicketDto> TicketDtos { get; set; }

    protected override System.Threading.Tasks.Task OnInitializedAsync()
    {
        User currentUser = new User()
        {
            UserID = 1,
            UserName = "Current User",
            IsEmplo = true
        };

        colVis = new bool[14];
        for (int i = 0; i < colVis.Length; i++)
        {
            colVis[i] = true;
        }

        string dataSource = File.ReadAllText("E:\\My Project\\C# Project\\BlazorApp.Web\\DataFiles\\Subject.json");

        var myList = JsonConvert.DeserializeObject<List<sub>>(dataSource);

        TicketDtos = Enumerable.Range(1, 75).Select(x => new TicketDto()
        {
            TicketNo = (1000 + x).ToString(),
            TicketDate = DateTime.Now.AddDays(new Random().Next(-365, 365)),
            TicketTypeId = new Random().Next(1, 75),
            TicketTypeName = "Frist Type",
            Subject = (myList[new Random().Next(myList.Count - 1)].subject),
            Description = (myList[new Random().Next(myList.Count - 1)].Description),
            OpenOn = DateTime.Now.AddDays(new Random().Next(-360, 360)),
            OpenByUserId = new Random().Next(0, 20),
            OpenByUserName = "User",
            ClosedOn = (new DateTime?[] { null, DateTime.Now.AddDays(new Random().Next(-100, 100)) })[new Random().Next(2)],
            Closed = (new bool[] { true, false })[new Random().Next(2)],
            CloseByUserId = new Random().Next(0, 20),
            CloseByUserName = "User",
            CustomerId = new Random().Next(0, 100),
            AssetId = new Random().Next(0, 1000),
            Priority = (new Priority[] { Priority.Critical, Priority.High, Priority.Normal, Priority.Low, Priority.Lowest })[new Random().Next(5)],
            CustomerName = (myList[new Random().Next(myList.Count - 1)].CustomrName),
            AssetName = (myList[new Random().Next(myList.Count - 1)].AssetName),
            DeviceId = new Random().Next(0, 100),
            DeviceName = (myList[new Random().Next(myList.Count - 1)].DeviceName),
            IsSelected = false,
            TicketDetails = Enumerable.Range(1, new Random().Next(3, 8)).Select(j => new TicketDetailDto
            {
                TicketNo = ((1000 + x).ToString()),
                CreatedOn = (DateTime.Now.AddDays(new Random().Next(-200, 200))),
                CreatedByUserId = new Random().Next(0, 20),
                CreatedUserName = "User",
                DetailDescription = (myList[new Random().Next(myList.Count - 1)].Description),
                AssignToTechnicianId = new Random().Next(0, 20),
                TechnicianName = "Technician Name",
                StartOn = (DateTime.Now.AddDays(new Random().Next(-200, 200))),
                EndOn = (DateTime.Now.AddDays(new Random().Next(-200, 200))),
                IsInternal = (new bool[] { true, false })[new Random().Next(2)]
            }).ToList()
        }).ToList();


        return base.OnInitializedAsync();
    }


    //send array of bool to show hide column
    public void ColumnVisiblity(bool[] col_Vis)
    {
        colVis = col_Vis;

    }

    // detect if new ticket show or not
    public void ShowContent(bool isNewTicket)
    {
        isNewTic = isNewTicket;
        isOpenTicket = false;
    }
    //send data to ticket view
    public void DisolayTicket(TicketDto ticketDto)
    {
        this.ticketDto = ticketDto;
        isOpenTicket = true;

    }

    public class sub
    {
        public string subject { get; set; }
        public string Description { get; set; }
        public string CustomrName { get; set; }
        public string AssetName { get; set; }
        public string DeviceName { get; set; }
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
