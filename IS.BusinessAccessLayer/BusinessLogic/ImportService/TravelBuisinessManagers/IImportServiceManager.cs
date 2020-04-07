using ImportService.BusinessAccessLayer.BusinessLogic.Models;
using IS.BusinessAccessLayer.BusinessLogic.ImportService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImportService.BusinessAccessLayer.ImportServiceBuisinessManagers
{
    public interface IImportServiceManager
    {
        /// <summary>
        /// Executes import of the package based on the import settings
        /// </summary>
        ImportResult CreateImportProgram(ImportSettings importRequest);
    }
}