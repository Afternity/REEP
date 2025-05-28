using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using REEP.Application.Interfaces.InterfaceRepositories;
using REEP.Persistence.Data.DbContexts;
using REEP.Persistence.Data.Repositories;

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
                    npgsqlOptions.MigrationsAssembly("REEP.Persistence");

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

            services.AddScoped<IContractTypeRepository, ContractTypeRepository>();

            return services;
        }
    }
}
