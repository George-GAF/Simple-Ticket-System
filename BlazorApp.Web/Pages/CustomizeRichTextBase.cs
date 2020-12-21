using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Inputs;
using System.IO;

namespace BlazorApp.Web.Pages
{
    public class CustomizeRichTextBase : ComponentBase
    {
        [Parameter]
        public string TextValue { get; set; }
        [Parameter]
        public string Height { get; set; }

        [Parameter]
        public EventCallback<bool> SaveButMethod { get; set; }


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


        
    }
}