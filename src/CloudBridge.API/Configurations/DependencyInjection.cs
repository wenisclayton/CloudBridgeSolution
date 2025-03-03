using Amazon;
using Amazon.SQS;
using Amazon.Runtime;
using CloudBridge.Messaging;
using CloudBridge.API.Services;
using CloudBridge.API.Middleware;
using Microsoft.Extensions.Options;
using CloudBridge.Messaging.Providers;
using CloudBridge.Shared.Configurations;

namespace CloudBridge.API.Configurations;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IPedidoService, PedidoService>();
        return services;
    }

    public static IServiceCollection AddAwsConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AppConfig>(configuration.GetSection("AppConfig"));
    
        services.AddSingleton<IAmazonSQS>(sp =>
        {
            var appAwsConfig = sp.GetRequiredService<IOptions<AppConfig>>().Value.AWS;

            var credentials = new BasicAWSCredentials(appAwsConfig.AccessKey, appAwsConfig.SecretKey);
            var region = RegionEndpoint.GetBySystemName(appAwsConfig.Region ?? "sa-east-1");
        
            return new AmazonSQSClient(credentials, new AmazonSQSConfig
            {
                RegionEndpoint = region
            });
        });

        services.AddTransient<AwsSqsService>();
        return services;
    }
    
     public static IServiceCollection AddApplicationConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppConfig>(configuration);
            services.AddSingleton(sp => sp.GetRequiredService<IOptions<AppConfig>>().Value);
            services.AddSingleton<IConfiguration>(configuration);
            return services;
        }

        public static IServiceCollection AddMessagingServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAwsConfig(configuration);
            
            // // Configuração do AWS SQS
            // services.AddSingleton<IAmazonSQS>(sp =>
            // {
            //     return new AmazonSQSClient(RegionEndpoint.USEast1);
            // });
            
            // Outras configurações de mensageria
            services.AddSingleton<AzureServiceBusService>();
            services.AddSingleton<GcpPubSubService>();
            services.AddSingleton<RabbitMqService>();

            // Registrar a fábrica e o serviço padrão
            services.AddSingleton<MessageQueueServiceFactory>();
            services.AddSingleton<IMessageQueueService, AwsSqsService>();

            // Configuração do Options Pattern para mensageria
            services.Configure<MessageQueueDefaultSettings>(configuration.GetSection("MessageQueueDefault"));
            services.Configure<MessageQueueSettings>(configuration.GetSection("MessageQueueSettings"));

            return services;
        }

        // public static IServiceCollection AddServerlessServices(this IServiceCollection services, IConfiguration configuration)
        // {
        //     // Registrar handlers de mensageria
        //     services.AddSingleton<AwsSqsHandler>();
        //     services.AddSingleton<AzureServiceBusHandler>();
        //     services.AddSingleton<GcpPubSubHandler>();
        //     services.AddSingleton<RabbitMqHandler>();
        //
        //     // Registrar triggers
        //     services.AddSingleton<AwsSqsTrigger>();
        //     services.AddSingleton<AzureServiceBusTrigger>();
        //     services.AddSingleton<GcpPubSubTrigger>();
        //     services.AddSingleton<RabbitMqTrigger>();
        //
        //     // Outros serviços serverless
        //     services.AddSingleton<MessageQueueServiceFactory>(); // Se necessário, verifique se a duplicação é intencional
        //     services.AddApplicationServices();
        //     services.AddSingleton<HandlerFactory>();
        //
        //     return services;
        // }
        
        public static IApplicationBuilder UseCustomExceptionHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
}