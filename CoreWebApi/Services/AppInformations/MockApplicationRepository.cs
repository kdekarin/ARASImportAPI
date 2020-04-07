using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWebApi.Models.Interfaces;
using CoreWebApi.Models.AppInformations;

namespace CoreWebApi.Services.AppInformations
{
    public class MockApplicationRepository : IApplicationRepository
    {
        private ApplicationInformation _applicationInformation;

        public MockApplicationRepository()
        {
            var applicationAssemblyInformation = PlatformServices.Default.Application;

            ApplicationInformation applicationInformation = new ApplicationInformation()
            {
                ApplicationDescription = "ARAS - Package Import service",
                Id = 101,
                ApplicationBasePath = applicationAssemblyInformation.ApplicationBasePath,
                ApplicationName = applicationAssemblyInformation.ApplicationName,
                ApplicationVersion = applicationAssemblyInformation.ApplicationVersion,
                RuntimeFramework = applicationAssemblyInformation.RuntimeFramework
            };
            _applicationInformation = applicationInformation;
        }

        ApplicationInformation IApplicationRepository.GetApplicationsInformations()
        {
            return _applicationInformation;
        }
    }
}
