namespace CloudBridge.Messaging;

public interface IMessageQueueService
{
    Task PublicarMensagemAsync(string mensagem);
}