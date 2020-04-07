using System;
using System.Collections.Generic;
using System.Text;

namespace ImportService.BusinessAccessLayer.BusinessLogic.Models
{
    public class ImportResult
    {
        public string GUID { get; set; }
        public string ErrorReason { get; set; }
        public bool IsError { get; set; }
    }
}
