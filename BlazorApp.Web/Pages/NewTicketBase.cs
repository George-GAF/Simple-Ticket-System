using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Syncfusion.Blazor.DocumentEditor;
using Syncfusion.Blazor.Inputs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;

namespace BlazorApp.Web.Pages
{
    public class NewTicketBase : ComponentBase
    {
        [Parameter]
        public EventCallback<bool> CloseNewTicket { get; set; }

        protected bool isDone { get; set; } = false;
        protected string textValue { get; set; } = string.Empty;

        public bool isChecked { get; set; }
        //-----------------------------------------------------
        public List<ChooseList> CusList { get; set; }
        public int CusID { get; set; }

        public List<ChooseList> TTypeList { get; set; }
        public int TTypeID { get; set; }

        public List<ChooseList> AssList { get; set; }
        public int AssID { get; set; }
        public string AssitName { get; set; } = string.Empty;

        public List<ChooseList> DevList { get; set; }
        public int DevID { get; set; }
        public string DeviceName { get; set; } = string.Empty;

        public List<ChooseList> PriList { get; set; }
        public int PriID { get; set; }
        //-----------------------------------------------------
        public bool ShowDeviceLabel { get; set; } = false;

        public string Subject { get; set; }

        protected override System.Threading.Tasks.Task OnInitializedAsync()
        {
            string dataSource = File.ReadAllText("E:\\My Project\\C# Project\\BlazorApp.Web\\DataFiles\\CustomerName.json");
            var myList = JsonConvert.DeserializeObject<List<ChooseList>>(dataSource);
            CusList = Enumerable.Range(0, myList.Count-1).Select(x => new ChooseList()
            {
                ID = x,
                Text = myList[x].Text
            }).ToList();

             dataSource = File.ReadAllText("E:\\My Project\\C# Project\\BlazorApp.Web\\DataFiles\\Asset.json");
             myList = JsonConvert.DeserializeObject<List<ChooseList>>(dataSource);
            AssList = Enumerable.Range(1, myList.Count - 1).Select(x => new ChooseList()
            {
                ID = x,
                Text = myList[x-1].Text
            }).ToList();

            dataSource = File.ReadAllText("E:\\My Project\\C# Project\\BlazorApp.Web\\DataFiles\\Device.json");
            myList = JsonConvert.DeserializeObject<List<ChooseList>>(dataSource);
            DevList = Enumerable.Range(1, myList.Count - 1).Select(x => new ChooseList()
            {
                ID = x,
                Text = myList[x-1].Text
            }).ToList();



            PriList = new List<ChooseList>()
            {
                new ChooseList(){ ID = 0 , Text = Priority.Lowest.ToString()},
                new ChooseList(){ ID = 1 , Text = Priority.Low.ToString()},
                new ChooseList(){ ID = 2 , Text = Priority.Normal.ToString()},
                new ChooseList(){ ID = 3 , Text = Priority.High.ToString()},
                new ChooseList(){ ID = 4 , Text = Priority.Critical.ToString()},
            };
                

            return base.OnInitializedAsync();
        }
        protected void OnChange(UploadChangeEventArgs args)
        {
            foreach (var file in args.Files)
            {
                var path = @"path" + file.FileInfo.Name;
                FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.Write);
                file.Stream.WriteTo(filestream);
                filestream.Close();
                file.Stream.Close();
            }
        }
        protected void ChangeState(bool isSave)
        {
            if (isSave)
            {
                string g = textValue;
                // add to database
                TicketDto ticketDto = new TicketDto()
                {

                };
            }
            
            CloseNewTicket.InvokeAsync(isDone);
        }

        //get asset name form list
        protected void GetAssetName()
        {
            var item = AssList.FirstOrDefault(i => i.ID == AssID);
            if (item != null)
                AssitName = item.Text;
            else
                AssitName = "Not Exist";
        }

        protected void GetDeviceName()
        {
            var item = DevList.FirstOrDefault(i => i.ID == DevID);
            if (item != null)
                DeviceName = item.Text;
            else
                DeviceName = "Not Exist";
        }
    }
    public class ChooseList
    {
        public int ID { get; set; }
        public string Text { get; set; }
    }
}
