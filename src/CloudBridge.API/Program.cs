using System.Text.Json;
using Scalar.AspNetCore;
using CloudBridge.API.Logging;
using CloudBridge.API.Configurations;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Configura o Serilog utilizando o método de extensão
builder.Host.UseCustomSerilog();

// Configurações e registros de serviços
builder.Services
    .AddApplicationConfigurations(configuration)
    .AddMessagingServices(configuration)
    .AddApplicationServices();
//.AddServerlessServices(configuration);

// Em ambiente de desenvolvimento, adicione os User Secrets
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

// Configuração de Swagger e Endpoints
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração dos controllers e opções JSON
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.WriteIndented = true;
});

var app = builder.Build();

// Adiciona o middleware usando o método de extensão
app.UseCustomExceptionHandling();

// Configurações específicas para ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();