using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Models.HTTPObjects
{
    public class ReqImportSettings
    {
        public string GUID { get; set; }
        //Authorisation
        public string ServerURL { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string DatabaseName { get; set; }
        //Release management
        public string Description { get; set; }
        public string Release { get; set; }
        //Import Settings
        public string ManifestFileName { get; set; }
        public string ImportDirectory { get; set; }
        public bool ShallMerge { get; set; }
        public bool ShallLogVerbose { get; set; }
        public int? Level { get; set; }
        public bool ShallImportInThorughMode { get; set; }
        //File settings
        private string ConsoleUpgradeToolLocation { get; set; }
        private string LogFileLocation { get; set; }
    }
}
