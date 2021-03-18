using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SmartLocker.WebAPI.Options;

namespace SmartLocker.WebAPI.ServiceInstallers.Installers
{
    public class JwtAuthInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            JwtOptions jWTOptions = new();
            configuration.GetSection(JwtOptions.SectionName).Bind(jWTOptions);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jWTOptions.Issuer,

                        ValidateAudience = true,
                        ValidAudience = jWTOptions.Audience,

                        ValidateLifetime = true,

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = jWTOptions.GetSymmetricSecurityKey()
                    };
                });
        }
    }
}
