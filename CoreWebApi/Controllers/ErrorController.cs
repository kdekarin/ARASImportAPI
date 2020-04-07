using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreWebApi.Controllers
{
    public class ErrorController : Controller
    {
        private ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [Route("Error/{statuscode}")]
        public IActionResult Index(int statuscode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statuscode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found";
                    ViewBag.Path = statusCodeResult?.OriginalPath;
                    ViewBag.Qs = statusCodeResult?.OriginalQueryString;
                    _logger.LogWarning($"404 Error occured. Path ={statusCodeResult?.OriginalPath} and QueryString = {statusCodeResult?.OriginalQueryString}");

                    break;
                default:
                    _logger.LogWarning($"{statuscode} Error occured. Path ={statusCodeResult?.OriginalPath} and QueryString = {statusCodeResult?.OriginalQueryString}");
                    break;
            }
            return View("NotFound");
        }

        [AllowAnonymous]
        [Route("Error")]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerFeature>();

            _logger.LogError($"Exception occured. ExceptionMessage: {exceptionDetails?.Error.Message} , Stack trace: {exceptionDetails?.Error?.StackTrace}");

            ViewBag.ExceptionMessage = exceptionDetails?.Error?.Message;
            ViewBag.StackTrace = exceptionDetails?.Error?.StackTrace;
            ViewBag.Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            return View("Error");
        }
    }
}
