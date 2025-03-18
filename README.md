# Casamento Lucas & Helena Backend

## Set environment

Set development or production environment on powershell.

`$env:DOTNET_ENVIRONMENT="Development"`\
`$env:DOTNET_ENVIRONMENT="Production"`

Use this command to see the environment variables:

`Get-ChildItem Env:`


## Configure Environment

Config `appsettings.Development.json` as:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "Postgres": "Host=localhost;Database=seu_banco_dev;Username=seu_usuario_dev;Password=sua_senha_dev"
  }
}

```

Config `appsettings.json` as:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "Postgres": "Host=seu_host_producao;Database=seu_banco_producao;Username=seu_usuario;Password=sua_senha"
  }
}

```