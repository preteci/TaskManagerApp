using System.Runtime.CompilerServices;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace TaskManagerV1.Extentions
{
    public static class AplicationServiceExtension
    {
        public static IServiceCollection AddAplicationService(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            services.AddCors();

            return services;
        }
    }
}
