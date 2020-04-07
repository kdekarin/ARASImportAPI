using CoreWebApi.Models.AppInformations;
using Microsoft.AspNetCore.Mvc;
using CoreWebApi.Models.Interfaces;
using CoreWebApi.ViewModels;
using ImportService.BusinessAccessLayer.ImportServiceBuisinessManagers;
using ImportService.BusinessAccessLayer.ImportServiceBusinessFactories;

namespace CoreWebApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApplicationRepository _applicationRepository;
        IImportServiceManager importServiceManager;

        //This is called constructor injection in the dependency injection
        public HomeController(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
            importServiceManager = new ImportServiceFactory().CreateImportServiceManager();
        }

        public ViewResult Index()
        {
            ////Example of storngly coupled model:
            ApplicationInformation model = _applicationRepository.GetApplicationsInformations();
            HomeDetailsViewModel viewModel = new HomeDetailsViewModel()
            {
                ApplicationInformation = model
            };
            //Example of loosely coupled model:
            ViewData["PageTitle"] = model.ApplicationName;
            ViewBag.ApplicationVersion = model.ApplicationVersion;
            return View("Views/Home/Index.cshtml", viewModel);
        }

        public ViewResult About()
        {
            return View("Views/Home/About.cshtml");
        }
    }
}
