using JobPortal.Application.Common.Interfaces.Repositories;
using JobPortal.Infrastructure.Persistence;
using JobPortal.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddApplicationDependencies(this IServiceCollection services) { }
        public static void AddPersistenceDependencies(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<JobPortalDbContext>(options =>
                options.UseSqlServer("Server=.\\SAMSON1;Database=JobPortalTestInfra;User Id=sa;password=123456;Encrypt=false;Trusted_Connection=True;TrustServerCertificate=True;"));

            services.AddScoped<IAccountRepository, AccountRepository>();
        }
        public static void AddInfrastructureDependencies(this IServiceCollection services) { }
    }
}
