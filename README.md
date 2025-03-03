# CloudBridgeSolution

CloudBridgeSolution é uma solução modular e escalável, projetada para integrar diferentes ambientes de nuvem e gerenciar dinamicamente provedores de mensageria. Desenvolvida com .NET 9 e fundamentada em princípios como SOLID, Clean Code e Design Patterns, a solução garante alta qualidade de código, facilidade de manutenção e evolução contínua.

## Sumário

- [Visão Geral](#visão-geral)
- [Arquitetura do Projeto](#arquitetura-do-projeto)
- [Estrutura de Pastas](#estrutura-de-pastas)
- [Tecnologias e Ferramentas](#tecnologias-e-ferramentas)
- [Infraestrutura](#infraestrutura)
- [Mensageria](#mensageria)
- [Documentação](#documentação)
- [Testes](#testes)

## Visão Geral

A **CloudBridgeSolution** foi concebida para facilitar a integração entre diversas plataformas de nuvem, permitindo a escolha dinâmica do provedor de mensageria (AWS SQS, Azure Service Bus, GCP Pub/Sub e RabbitMQ) por meio do `MessageQueueServiceFactory`. A solução foi desenvolvida com ênfase em boas práticas e uma arquitetura modular que possibilita escalabilidade e rápida adaptação a novos requisitos.

## Arquitetura do Projeto

- **CloudBridge.API:**  
  Desenvolvida em .NET 9, esta API utiliza o Scalar para documentação, seguindo os princípios SOLID, Clean Code e Design Patterns. Possui camadas para configuração, controllers, logging, middleware e serviços.

- **CloudBridge.Domain:**  
  Contém os modelos e a lógica de negócio, incluindo os agregados de domínio e utilitários para a modelagem das entidades.

- **CloudBridge.Infrastructure:**  
  Gerencia as configurações e integrações com os diferentes provedores de nuvem, além de serviços como autenticação e gerenciamento do ambiente.

- **CloudBridge.Messaging:**  
  Responsável pela integração com os provedores de mensageria (AWS SQS, Azure Service Bus, GCP Pub/Sub e RabbitMQ) através do `MessageQueueServiceFactory`, que escolhe dinamicamente o provedor mais adequado.

- **CloudBridge.Serverless:**  
  Implementa funções serverless, contendo handlers, triggers e factories para facilitar a execução de funções nos respectivos provedores de nuvem.

- **CloudBridge.Shared:**  
  Disponibiliza recursos e contratos compartilhados, como DTOs e enums, para serem utilizados entre os módulos da solução.

## Estrutura de Pastas

```plaintext
CloudBridgeSolution
│   infra
│   ├── aws.tf
│   ├── azure.tf
│   ├── gcp.tf
│   ├── main.tf
│   ├── outputs.tf
│   ├── providers.tf
│   ├── rabbitmq.tf
│   ├── terraform.tfvars
│   └── variables.tf
│   src
│   ├── CloudBridge.API
│   │   ├── Configurations
│   │   │   ├── DependencyInjection.cs
│   │   │   └── MessageQueueSettings.cs
│   │   ├── Controllers
│   │   │   └── PedidoController.cs
│   │   ├── Extensions
│   │   │   └── ConfigurationExtensions.cs
│   │   ├── Logging
│   │   │   └── LoggingService.cs
│   │   ├── logs
│   │   │   ├── log20250301.txt
│   │   │   └── log20250302.txt
│   │   ├── Middleware
│   │   │   └── ExceptionHandlingMiddleware.cs
│   │   ├── Properties
│   │   │   └── launchSettings.json
│   │   ├── Services
│   │   │   ├── IPedidoService.cs
│   │   │   └── PedidoService.cs
│   │   ├── appsettings.Development.json
│   │   ├── appsettings.json
│   │   ├── CloudBridge.API.csproj
│   │   ├── CloudBridge.API.csproj.user
│   │   ├── CloudBridge.API.http
│   │   └── Program.cs
│   ├── CloudBridge.Domain
│   │   ├── Models
│   │   │   └── PedidoAggregate
│   │   │       └── Pedido.cs
│   │   ├── Utilities
│   │   │   └── Modeling
│   │   │       └── Models
│   │   │           └── Entities_
│   │   │               ├── Entity.cs
│   │   │               ├── Entity`1.cs
│   │   │               ├── GuidIdentifiableEntity.cs
│   │   │               ├── Model.cs
│   │   │               └── MutableEntity.cs
│   │   ├── CloudBridge.Domain.csproj
│   │   └── CloudBridge.Domain.csproj.DotSettings
│   ├── CloudBridge.Infrastructure
│   │   ├── Configs
│   │   │   ├── AwsConfig.cs
│   │   │   ├── AzureConfig.cs
│   │   │   ├── GcpConfig.cs
│   │   │   └── RabbitMqConfig.cs
│   │   ├── AppConfig.cs
│   │   ├── AuthService.cs
│   │   ├── CloudBridge.Infrastructure.csproj
│   │   ├── EnvironmentManager.cs
│   │   └── MessageQueueSettings.cs
│   ├── CloudBridge.Messaging
│   │   ├── Providers
│   │   │   ├── AwsSqsService.cs
│   │   │   ├── AzureServiceBusService.cs
│   │   │   ├── GcpPubSubService.cs
│   │   │   └── RabbitMqService.cs
│   │   ├── src
│   │   ├── CloudBridge.Messaging.csproj
│   │   ├── IMessageQueueService.cs
│   │   └── MessageQueueServiceFactory.cs
│   ├── CloudBridge.Serverless
│   │   ├── Factories
│   │   │   └── HandlerFactory.cs
│   │   ├── Handlers
│   │   │   ├── AwsSqsHandler.cs
│   │   │   ├── AzureServiceBusHandler.cs
│   │   │   ├── GcpPubSubHandler.cs
│   │   │   ├── IMessageHandler.cs
│   │   │   └── RabbitMqHandler.cs
│   │   ├── Triggers
│   │   │   ├── AwsSqsTrigger.cs
│   │   │   ├── AzureServiceBusTrigger.cs
│   │   │   ├── GcpPubSubTrigger.cs
│   │   │   └── RabbitMqTrigger.cs
│   │   ├── CloudBridge.Serverless.csproj
│   │   ├── PedidoHandler.cs
│   │   └── Program.cs
│   └── CloudBridge.Shared
│       ├── DTOs
│       │   └── PedidoDto.cs
│       ├── Enums
│       │   └── ProviderEnum.cs
│       └── CloudBridge.Shared.csproj
│   tests
│   └── CloudBridge.Tests
│       ├── CloudBridge.Tests.csproj
│       └── MessageQueueServiceTests.cs
│   .gitignore
│   CloudBridgeSolution.sln
│   CloudBridgeSolution.sln.DotSettings.user
│   README.md
```

## Tecnologias e Ferramentas

- **.NET 9:** Plataforma utilizada para o desenvolvimento da API e demais componentes da solução.
- **Scalar:** Ferramenta de documentação que substitui o Swagger.
- **Terraform:** Utilizado para provisionamento e gerenciamento da infraestrutura nos provedores de nuvem (AWS, Azure, GCP e RabbitMQ).
- **Princípios de Desenvolvimento:** Adoção dos princípios SOLID, Clean Code e Design Patterns para garantir um código de alta qualidade e fácil manutenção.

## Infraestrutura

A pasta **infra** contém os arquivos de configuração do Terraform que permitem o provisionamento e gerenciamento da infraestrutura para os seguintes provedores:
- **AWS**
- **Azure**
- **GCP**
- **RabbitMQ**

Esses scripts garantem uma infraestrutura padronizada, automatizada e escalável, facilitando a integração com diversas plataformas de nuvem.

## Mensageria

O módulo **CloudBridge.Messaging** integra a solução com diferentes provedores de mensageria, incluindo:
- **AWS SQS**
- **Azure Service Bus**
- **GCP Pub/Sub**
- **RabbitMQ**

O `MessageQueueServiceFactory` gerencia a escolha dinâmica do provedor de mensageria, oferecendo flexibilidade e adaptabilidade para diversos cenários e requisitos.


## Documentação

A documentação da API é gerada utilizando **Scalar**, que fornece uma visão detalhada dos endpoints, contratos e especificações da aplicação. Essa abordagem facilita o entendimento da API por parte dos desenvolvedores e promove uma integração mais eficaz.

## Testes

Os testes automatizados, localizados na pasta **tests/CloudBridge.Tests**, garantem a qualidade e robustez da aplicação. Eles permitem a detecção precoce de problemas e regressões, assegurando que novas alterações não comprometam o funcionamento da solução.


