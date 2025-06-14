using Microsoft.EntityFrameworkCore;
using REEP.Identity.Data.DbContexts;

namespace REEP.Identity.DependencyInjections
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabaseService(
            this IServiceCollection services,
            IConfiguration config)
        {
            var connetcionString = config.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connetcionString))
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found");

            services.AddDbContext<ReepAuthDbContext>(options =>
            {
                options.UseNpgsql(connetcionString, npgsqlOptions =>
                {
                    npgsqlOptions.MigrationsAssembly("REEP.Identity");

                    npgsqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorCodesToAdd: null);

                    npgsqlOptions.CommandTimeout(30);
                });

                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();

                options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
            });

            return services;
        }
    }
}
