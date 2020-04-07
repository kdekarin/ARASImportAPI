using Microsoft.AspNetCore.Mvc;
using System;
using CoreWebApi.Models.Interfaces;
using ImportService.BusinessAccessLayer.ImportServiceBuisinessManagers;
using ImportService.BusinessAccessLayer.ImportServiceBusinessFactories;
using IS.BusinessAccessLayer.BusinessLogic.ImportService.Models;
using CoreWebApi.Models.HTTPObjects;

namespace CoreWebApi.Controllers
{
    public class ImportServiceController : Controller
    {
        private readonly IApplicationRepository _applicationRepository;
        IImportServiceManager importServiceManager;

        public ImportServiceController(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
            importServiceManager = new ImportServiceFactory().CreateImportServiceManager();
        }

        /*
         * Example of HTTP request:
         * Type:POST
         * URL: https://localhost:44378/api/CreateImport/
         * Content-Type: application/json
         * Body:
           {	
            "guid": "abc",
	        "serverURL": "http://localhost/InnovatorServer",
	        "login": "admin",
	        "password": "************",
	        "databaseName": "InnovatorSolutions",
	        "description": "Some description",
	        "release": "rel9.2",
	        "manifestFileName": "imports.mf",
	        "importDirectory": "C:/Program Files (x86)/PackageImportExportUtilities/ConsoleUpgrade/01_Package/",
	        "shallMerge": true,
	        "shallLogVerbose": true,
	        "level": null,
	        "shallImportInThorughMode": true
           }
        */
        [HttpPost]
        [Route("api/CreateImport/")]
        [System.Web.Http.AllowAnonymous]
        public JsonResult CreateImport([FromBody]ReqImportSettings importSettings)
        {
            var importSettingsBll = new ImportSettings()
            {
                DatabaseName = importSettings.DatabaseName,
                Description = importSettings.Description,
                GUID = Guid.NewGuid().ToString(),
                ImportDirectory = importSettings.ImportDirectory.Replace(@"/",@"\"),
                Level = importSettings?.Level,
                Login = importSettings.Login,
                ManifestFileName = importSettings.ManifestFileName,
                Password = importSettings.Password,
                Release = importSettings.Release,
                ShallImportInThorughMode = importSettings.ShallImportInThorughMode,
                ServerURL = importSettings.ServerURL,
                ShallLogVerbose = importSettings.ShallLogVerbose,
                ShallMerge = importSettings.ShallMerge
            };
            var result = importServiceManager.CreateImportProgram(importSettingsBll);
            return Json(new { result });
        }
    }
}
