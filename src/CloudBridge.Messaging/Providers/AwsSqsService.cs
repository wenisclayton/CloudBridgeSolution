using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using CloudBridge.Shared.Configurations;
using Microsoft.Extensions.Options;

namespace CloudBridge.Messaging.Providers;

public class AwsSqsService(IAmazonSQS sqsClient, IOptions<AppConfig> config) : IMessageQueueService
{
    private readonly IAmazonSQS _sqsClient = sqsClient ?? throw new ArgumentNullException(nameof(sqsClient));
    private readonly string _queueUrl = config.Value.AWS.SQSQueueUrl 
                                        ?? throw new ArgumentNullException("A configuração da fila SQS não foi encontrada.");

    public async Task PublicarMensagemAsync(string mensagem)
    {
        if (string.IsNullOrWhiteSpace(mensagem))
        {
            throw new ArgumentException("A mensagem não pode ser vazia.");
        }

        var request = new SendMessageRequest
        {
            QueueUrl = _queueUrl,
            MessageBody = mensagem
        };

        var response = await _sqsClient.SendMessageAsync(request);
        Console.WriteLine($"Mensagem enviada para {_queueUrl}. ID: {response.MessageId}");
    }
}
