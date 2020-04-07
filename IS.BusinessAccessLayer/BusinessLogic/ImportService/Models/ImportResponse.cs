using System;
using System.Collections.Generic;
using System.Text;

namespace ImportService.BusinessAccessLayer.BusinessLogic.Models
{
    public class ImportResponse
    {
        public List<ImportResult> ImportResults { get; set; } = new List<ImportResult>();
    }
}
