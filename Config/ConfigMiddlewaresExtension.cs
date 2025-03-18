using CasamentoLH_Backend.Core.Middlewares.ErrorHandler;

namespace CasamentoLH_Backend.Config;

public static partial class ServiceCollectionExtension
{
    public static IServiceCollection ConfigMiddlewares(this IServiceCollection services)
    {
        services.AddTransient<ErrorHandlingMiddleware>();
        // services.AddTransient<AuthenticationMiddleware>();
        return services;
    }
}