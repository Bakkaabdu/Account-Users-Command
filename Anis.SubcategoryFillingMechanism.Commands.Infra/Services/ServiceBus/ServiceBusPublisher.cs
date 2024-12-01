using Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Repositories;
using Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Services.ServiceBus;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Entities;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Events;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;

namespace Anis.SubcategoryFillingMechanism.Commands.Infra.Services.ServiceBus
{
    public class ServiceBusPublisher : IServiceBusPublisher
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ServiceBusSender _sender;
        private readonly ILogger<ServiceBusPublisher> _logger;

        private static readonly object _lockObject = new();

        public ServiceBusPublisher(IServiceProvider serviceProvider, IConfiguration configuration, ServiceBusClient serviceBusClient, ILogger<ServiceBusPublisher> logger)
        {
            _serviceProvider = serviceProvider;
            _sender = serviceBusClient.CreateSender(configuration["ServiceBus:Topic"]);
            _logger = logger;
        }

        public void StartPublish()
        {
            // Don't wait .
            Task.Run(PublishNonPublishedMessages);
        }

        private void PublishNonPublishedMessages()
        {
            try
            {
                lock (_lockObject)
                {
                    using var scope = _serviceProvider.CreateScope();

                    var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                    var messages = unitOfWork.OutboxMessages.GetAllAsync().GetAwaiter().GetResult();

                    PublishAndRemoveMessagesAsync(messages, unitOfWork).GetAwaiter().GetResult();
                }
            }
            catch (Exception e)
            {
                _logger.LogCritical("outbox send error : {e}", e);
            }
        }

        private async Task PublishAndRemoveMessagesAsync(IEnumerable<OutboxMessage> messages, IUnitOfWork unitOfWork)
        {
            foreach (var message in messages)
            {
                await SendMessageAsync(message.Event!);

                await unitOfWork.OutboxMessages.RemoveAsync(message);

                await unitOfWork.SaveChangesAsync();
            }

            await Task.CompletedTask;
        }

        private async Task SendMessageAsync(Event @event)
        {
            var body = new MessageBody()
            {
                AggregateId = @event.AggregateId,
                DateTime = @event.DateTime,
                Sequence = @event.Sequence,
                Type = @event.Type.ToString(),
                UserId = @event.UserId,
                Version = @event.Version,
                Data = ((dynamic)@event).Data
            };

            var messageBody = JsonConvert.SerializeObject(body);

            var message = new ServiceBusMessage(Encoding.UTF8.GetBytes(messageBody))
            {
                CorrelationId = @event.Id.ToString(),
                MessageId = @event.Id.ToString(),
                PartitionKey = @event.AggregateId.ToString(),
                SessionId = @event.AggregateId.ToString(),
                Subject = @event.Type.ToString(),
                ApplicationProperties = {
                    { nameof(@event.AggregateId), @event.AggregateId },
                    { nameof(@event.Sequence), @event.Sequence },
                    { nameof(@event.Version), @event.Version },
                }
            };

            await _sender.SendMessageAsync(message);
        }

    }
}
