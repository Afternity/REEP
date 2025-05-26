using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using REEP.Persistence.Data.DbContexts;

namespace REEP.Persistence.DependencyInjections
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabaseServices(
            this IServiceCollection services,
            IConfiguration config)
        {
            var connetcionString = config.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connetcionString))
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found");

            services.AddDbContext<ReepDbContext>(options =>
            {
                options.UseNpgsql(connetcionString, npgsqlOptions =>
                {
                    npgsqlOptions.EnableRetryOnFailure(3);
                });

                options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
            });

            return services;
        }
    }
}
