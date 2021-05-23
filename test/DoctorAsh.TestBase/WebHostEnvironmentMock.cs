using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;

namespace DoctorAsh
{
    public class WebHostEnvironmentMock : IWebHostEnvironment
    {
        public string EnvironmentName { get; set; }
        public string ApplicationName { get; set; }
        public string ContentRootPath { get; set; }
        public IFileProvider ContentRootFileProvider { get; set; }
        public IFileProvider WebRootFileProvider { get; set; }
        public string WebRootPath { get; set; }

        public WebHostEnvironmentMock()
        {
            var absoluteRootPath = Path.GetFullPath(string.Format("..{0}..{0}..{0}..{0}..{0}src{0}DoctorAsh.Web", System.IO.Path.DirectorySeparatorChar));
            ContentRootPath = absoluteRootPath; //absolute path to your Web project
            WebRootPath = Path.Combine(absoluteRootPath, "wwwroot"); //this should point to wwwroot of your Web project
        }
    }
}