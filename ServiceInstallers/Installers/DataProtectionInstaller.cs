using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SmartLocker.WebAPI.ServiceInstallers.Installers
{
    public class DataProtectionInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataProtection();
        }
    }
}
