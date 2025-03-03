using CloudBridge.Shared.Configurations;
using Microsoft.Extensions.Configuration;

namespace CloudBridge.Shared.Extensions;

public static class ConfigurationExtensions
{
    
    /// <summary>
    /// Obtém as configurações de MessageQueueSettings do appsettings.json de forma fortemente tipada.
    /// </summary>
    /// <param name="configuration">Instância de IConfiguration</param>
    /// <returns>Instância de MessageQueueSettings</returns>
    public static MessageQueueSettings GetMessageQueueSettings(this IConfiguration configuration)
    {
        return configuration.GetSection("MessageQueue").Get<MessageQueueSettings>() 
               ?? throw new InvalidOperationException("Configuração 'MessageQueue' não encontrada.");
    }
}