using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading.Tasks;

namespace CoreWebApi.Models.AppInformations
{
    public class ApplicationInformation
    {
        public int Id { get; set; }
        public string ApplicationName { get; set; }
        public string ApplicationDescription { get; set; }
        public string ApplicationBasePath { get; set; }
        public string ApplicationVersion { get; set; }
        public FrameworkName RuntimeFramework { get; set; }
    }
}
