using System.Text.Json.Serialization;

namespace CasamentoLH_Backend.Config;

public static partial class ServiceCollectionExtension
{
    public static IServiceCollection ConfigMainConfigs(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Program));
        services.AddCors();

        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

        services.AddAuthorization();    
        services.AddProblemDetails();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        return services;
    }
}