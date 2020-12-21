using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Inputs;
using System;
using System.IO;
using static BlazorApp.Web.Pages.TaskBase;

namespace BlazorApp.Web.Pages
{
    public class OpenTicketBase : ComponentBase
    {
        [Parameter]
        public TicketDto TicketDto { get; set; }
       
        public bool IsShowReplayTextRichBox { get; set; } = false;
        protected string TextValue { get; set; } = string.Empty;

        protected override System.Threading.Tasks.Task OnInitializedAsync()
        {
            
            return base.OnInitializedAsync();
        }

        public void ShowReplayTextRichBox()
        {
            IsShowReplayTextRichBox = true;
        }

        protected void OnChange(UploadChangeEventArgs args)
        {
            foreach (var file in args.Files)
            {
                var path = @"path" + "ne name";
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
                TicketDto.TicketDetails.Add(new TicketDetailDto
                {
                    TicketNo = TicketDto.TicketNo,
                    DetailDescription = TextValue,
                    CreatedOn = DateTime.Now,
                    StartOn = DateTime.Now,
                });
            }

            IsShowReplayTextRichBox = false;
        }


    }
}
