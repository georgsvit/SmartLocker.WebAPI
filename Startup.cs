using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SmartLocker.WebAPI.Extensions;
using SmartLocker.WebAPI.Options;
using System.Globalization;
using System.Linq;

namespace SmartLocker.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.InstallServicesInAssembly(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<CultureOptions> cultureOptions)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartLocker.WebAPI v1"));
            }

            SetCultureConfigurationValues(cultureOptions, out string defaultCultureName, out CultureInfo[] supportedCultures);

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCultureName),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void SetCultureConfigurationValues(
            IOptions<CultureOptions> options, out string defaultCultureName, out CultureInfo[] supportedCultures)
        {
            CultureOptions cultureOptions = options.Value;
            defaultCultureName = cultureOptions.DefaultCulture;
            supportedCultures = cultureOptions.SupportedCultures.Select(culture => new CultureInfo(culture)).ToArray();
        }
    }
}
