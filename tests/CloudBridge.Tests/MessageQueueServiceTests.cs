using CloudBridge.Messaging.Providers;
using Microsoft.Extensions.Configuration;

namespace CloudBridge.Tests
{
    public class MessageQueueServiceTests
    {
        [Fact]
        public async Task Deve_PublicarMensagem_NoRabbitMQ()
        {
            var service = new RabbitMqService(new ConfigurationBuilder().Build());
            await service.PublicarMensagemAsync("Teste de Mensagem");
            Assert.True(true);
        }
    }
}
