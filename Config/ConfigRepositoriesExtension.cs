using CasamentoLH_Backend.Core.Repositories;
using CasamentoLH_Backend.Domain.Models;
using CasamentoLH_Backend.Domain.Repositories;

namespace CasamentoLH_Backend.Config;

public static partial class ServiceCollectionExtension
{
    public static IServiceCollection ConfigEntitiesRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBaseRepository<Guest>, GuestRepository>();
        services.AddScoped<IGuestRepository, GuestRepository>();
        
        services.AddScoped<IBaseRepository<GuestGroup>, GuestGroupRepository>();
        services.AddScoped<IGuestGroupRepository, GuestGroupRepository>();

        return services;
    }
}