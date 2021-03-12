using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartLocker.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLocker.WebAPI.ServiceInstallers.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<JwtTokenService>();
        }
    }
}
