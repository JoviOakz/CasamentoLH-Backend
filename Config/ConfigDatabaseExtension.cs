using Microsoft.EntityFrameworkCore;

namespace CasamentoLH_Backend.Config;

public static partial class ServiceCollectionExtension
{
    public static IServiceCollection ConfigDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Postgres");

        services.AddDbContext<CasamentoLHContext>(
            options => options.UseNpgsql(connectionString)
        );

        return services;
    }
}
