using CasamentoLH_Backend.Core.Services;
using CasamentoLH_Backend.Domain.Services;

namespace CasamentoLH_Backend.Config;

public static partial class ServiceCollectionExtension
{
    public static IServiceCollection ConfigEntitiesServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));

        services.AddScoped<IGuestService, GuestService>();
        services.AddScoped<IGuestGroupService, GuestGroupService>();
        return services;
    }
}