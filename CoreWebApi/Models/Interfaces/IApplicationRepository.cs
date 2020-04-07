using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWebApi.Models.AppInformations;

namespace CoreWebApi.Models.Interfaces
{
    public interface IApplicationRepository
    {
        public ApplicationInformation GetApplicationsInformations();
    }
}
