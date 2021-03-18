using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartLocker.WebAPI.Data;

namespace SmartLocker.WebAPI.ServiceInstallers.Installers
{
    public class DbContextInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
#if DEBUG
            string connectionString = configuration.GetConnectionString("DevConnection");
#else
            string connectionString = configuration.GetConnectionString("ReleaseConnection");
#endif

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connectionString)
            );
        }
    }
}
