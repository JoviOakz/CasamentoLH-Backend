using CasamentoLH_Backend.Config;
using CasamentoLH_Backend.Core.Middlewares.ErrorHandler;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigDomain(builder.Configuration);

builder.Services
    .ConfigDatabase(builder.Configuration)
    // .ConfigMiddlewares()
    .ConfigAddOns()
    .ConfigEntitiesRepositories()
    .ConfigEntitiesServices()
    .ConfigMainConfigs();


var app = builder.Build();

if (app.Environment.IsProduction())
{
    Console.WriteLine("Setting variable DOTNET_ENVIRONMENT to Production");
    Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", "Production", EnvironmentVariableTarget.Process);
}

string environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Development";
Console.WriteLine($"Environment: {environment}");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());


app.UseAuthorization();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();

app.Run();