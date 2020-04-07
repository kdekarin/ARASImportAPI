
using ImportService.BusinessAccessLayer.ImportServiceBuisinessManagers;
using ImportService.BusinessAccessLayer.TravelBuisinessManagers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImportService.BusinessAccessLayer.ImportServiceBusinessFactories
{
    public class ImportServiceFactory
    {
        /// <summary>
        /// Creates new instance of TravelOfferDALManager class
        /// </summary>
        public IImportServiceManager CreateImportServiceManager() {
            IImportServiceManager bllManager = new ImportServiceManager();
            return bllManager;
        }
    }
}
