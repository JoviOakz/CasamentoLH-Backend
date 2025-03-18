namespace CasamentoLH_Backend.Config;

public static partial class ServiceCollectionExtension
{
    public static ConfigureWebHostBuilder ConfigDomain(this ConfigureWebHostBuilder builder, ConfigurationManager configuration)
    {
        var port = int.Parse(configuration.GetSection("App")["port"] ?? "0");
        var ip = System.Net.IPAddress.Parse(configuration.GetSection("App")["url"]!);
        builder.UseKestrel(options => {
            options.Listen(ip, port);
        });

        return builder;
    }
}