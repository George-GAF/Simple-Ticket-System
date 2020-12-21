
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Data;
using Syncfusion.Blazor.Grids;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace BlazorApp.Web.Pages
{
    public class TaskBase : ComponentBase
    {
        public List<TicketDto> TicketDtos { get; set; }
        public List<TicketDetailDto> TicketDetailDtos { get; set; }
        public List<TechName> techNames { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Parameter]
        public bool[] ColumnVisb { get; set; }
        [Parameter]
        public EventCallback<TicketDto> OpenTicket { get; set; }
        [Parameter]
        public User Currentuser { get; set; }

        public int techId { get; set; }

        public bool PopupVisible { get; set; } = false;
        public bool TicketsSelected { get; set; } = false;
        public string AssginMessage { get; set; } = "No Ticket Selected";
        public List<ChooseList> list { get; set; }

        public List<TicketDto> ticketDtosCopy { get; set; }

        protected override void OnInitialized()
        {
            string dataSource = File.ReadAllText("E:\\My Project\\C# Project\\BlazorApp.Web\\DataFiles\\Subject.json");

            var myList = JsonConvert.DeserializeObject<List<sub>>(dataSource);

            //var i = myList[0].subject;
            //  SubjectText = (new string[] { "Samothing Must do", "maybe Do", "in moring task", "last time to remind", "Do Immdetily" })[new Random().Next(5)],
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
           
            techNames = Enumerable.Range(1, 20).Select(x => new TechName
            {
                ID = new Random().Next(1, 20),
                Name = $"Technician Name {x}"
            }).ToList();
        }

        public void Assign()
        {
            TicketsSelected = TicketDtos.FirstOrDefault(i => i.IsSelected) != null ? true : false;
            PopupVisible = true;
        }
        // get tech id 
        public void TecNameRow(RowSelectEventArgs<TechName> args)
        {
            techId = args.Data.ID;
        }
        // save assgin tech id
        public void AddTechToTicket()
        {
            if (techNames.FirstOrDefault(i => i.ID == techId) != null)
            {
                // run assin method with {techId} 

            }
            PopupVisible = false;
        }

        public void ChangeIsSelectedValue(int id)
        {
            bool c = !TicketDtos[id].IsSelected;
            TicketDtos[id].IsSelected = c;
            StateHasChanged();
        }

        public void RecordClickHandler(RecordClickEventArgs<TicketDto> ar)
        {
            if (ar.CellIndex != 0)
                OpenTicket.InvokeAsync(ar.RowData);
            else
            {
                ChangeIsSelectedValue(int.Parse(ar.RowIndex.ToString()));
            }
        }

        public void RowBound(RowDataBoundEventArgs<TicketDto> args)
        {
            if (args.Data.Priority == Priority.Critical)
            {
                args.Row.AddClass(new string[] { "critical" });
            }
            else if (args.Data.Priority == Priority.High)
            {
                args.Row.AddClass(new string[] { "height" });
            }
            else if (args.Data.Priority == Priority.Low)
            {
                args.Row.AddClass(new string[] { "low" });
            }
            else
            {
                args.Row.AddClass(new string[] { "med" });
            }
            //args.Row.AddClass(new string[] { "e-hover" });

        }

        public void SortData(string columnName, bool IsAsc)
        {
            ticketDtosCopy = TicketDtos;
            List<TicketDto> newOne;
            if (IsAsc)
            {
                newOne = (from s in TicketDtos orderby columnName select s).ToList();
            }
            else
            {
                newOne = (from s in TicketDtos orderby columnName descending select s).ToList();
            }
            TicketDtos = newOne;
        }



        public class sub
        {
            public string subject { get; set; }
            public string Description { get; set; }
            public string CustomrName { get; set; }
            public string AssetName { get; set; }
            public string DeviceName { get; set; }
        }

        public class TechName
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }

    }
}
