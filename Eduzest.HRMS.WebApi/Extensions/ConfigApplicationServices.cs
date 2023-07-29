using Eduzest.HRMS.Repository.Interface;
using Eduzest.HRMS.Repository.Service;
using Eduzest.HRMS.WebApi.Services;

namespace Eduzest.HRMS.WebApi.Extensions
{
    public static class ConfigApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWorks>();
           

            services.AddTransient<IFileUploadService, FileUploadService>();
            services.AddTransient<AdminRepository>();
            return services;
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
    }
}
