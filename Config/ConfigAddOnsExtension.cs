namespace CasamentoLH_Backend.Config;

public static partial class ServiceCollectionExtension
{
    public static IServiceCollection ConfigAddOns(this IServiceCollection services)
    {
        // services.AddScoped<UserContext>();
        // services.AddSingleton<PasswordHasher<User>>();
        // services.AddScoped<IPaginationService, PaginationService>();
        // services.AddScoped<ILoginService, LoginService>();
        // services.AddScoped<IPermissionService, PermissionService>();

        return services;

    }
}