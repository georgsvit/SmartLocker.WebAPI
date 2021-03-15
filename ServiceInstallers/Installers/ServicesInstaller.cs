using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using SmartLocker.WebAPI.Services;

namespace SmartLocker.WebAPI.ServiceInstallers.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<AccountService>();
            services.AddTransient<UserService>();

            services.AddTransient<JwtTokenService>();
            services.AddTransient<DataService>();
            services.AddTransient<IStringLocalizer, LocalizationService>();
        }
    }
}
