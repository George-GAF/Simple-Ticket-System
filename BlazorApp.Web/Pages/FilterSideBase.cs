using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace BlazorApp.Web.Pages
{
    public class FilterSideBase : ComponentBase
    {
        [Parameter]
        public EventCallback<bool[]> SetColVis { get; set; }

        public List<ChooseList> list { get; set; }
        public bool[] IsChecked { get; set; }
        protected override void OnInitialized()
        {
            
            list = new List<ChooseList>()
            {
                new ChooseList(){ID=1 ,Text="Ticket Number"},
                new ChooseList(){ID=2 ,Text="Ticket Date"},
                new ChooseList(){ID=3 ,Text="Ticket Type Name"},
                new ChooseList(){ID=4 ,Text="Subject"},
                new ChooseList(){ID=5 ,Text="Description"},
                new ChooseList(){ID=6 ,Text="Open Date"},
                new ChooseList(){ID=7 ,Text="Open By"},
                new ChooseList(){ID=8 ,Text="Close Date"},
                new ChooseList(){ID=9 ,Text="Priority"},
                new ChooseList(){ID=10,Text="Status"},
                new ChooseList(){ID=11,Text="Close By"},
                new ChooseList(){ID=12,Text="Customer"},
                new ChooseList(){ID=13,Text="Asset"},
                new ChooseList(){ID=14,Text="Device"},
            };
            IsChecked = new bool[list.Count];
            for (int i = 0; i < IsChecked.Length; i++)
            {
                IsChecked[i] = true;
            }
        }

        public void onChange()
        {
           // Console.WriteLine("Check box clicked");
            SetColVis.InvokeAsync(IsChecked);
        }

    }
}
