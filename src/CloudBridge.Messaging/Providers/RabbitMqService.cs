using System.Text;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace CloudBridge.Messaging.Providers;

public class RabbitMqService : IMessageQueueService
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly string _queueName;

    public RabbitMqService(IConfiguration configuration)
    {
        var factory = new ConnectionFactory
        {
            HostName = configuration["RabbitMQ:HostName"],
            UserName = configuration["RabbitMQ:UserName"],
            Password = configuration["RabbitMQ:Password"]
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _queueName = configuration["RabbitMQ:QueueName"];

        _channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
    }

    public Task PublicarMensagemAsync(string mensagem)
    {
        var body = Encoding.UTF8.GetBytes(mensagem);
        _channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);

        return Task.CompletedTask;
    }
}
