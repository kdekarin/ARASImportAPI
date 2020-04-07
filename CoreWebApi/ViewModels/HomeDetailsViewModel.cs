using CoreWebApi.Models.AppInformations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.ViewModels
{
    public class HomeDetailsViewModel
    {
        public ApplicationInformation ApplicationInformation { get; set; }
        public string MainAuthorLinkedInPageUrl { get { return "https://de.linkedin.com/company/t-systems-on-site-services-gmbh"; } }
        public string MainAuthorXingInPageUrl { get { return "https://www.xing.com/companies/t-systemsonsiteservicesgmbh"; } }
    }
}
