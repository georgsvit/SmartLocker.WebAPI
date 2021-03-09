using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace SmartLocker.WebAPI.ServiceInstallers.Installers
{
    public class SwaggerGenInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(
            c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmartLocker.WebAPI", Version = "v1" });
            });
        }
    }
}
