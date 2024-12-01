using Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Services.ServiceBus;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Events;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text;

namespace Anis.SubcategoryFillingMechanism.Commands.Infra.Services.ServiceBus
{
    public class ServiceBusEventSender(IConfiguration configuration, ServiceBusClient serviceBusClient) : IServiceBusEventSender
    {
        private readonly ServiceBusSender _sender = serviceBusClient.CreateSender(configuration["ServiceBus:Topic"]);

        public async Task SendEventAsync(Event @event)
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

            var messageBody = JsonConvert.SerializeObject(body, new StringEnumConverter());

            var message = new ServiceBusMessage(Encoding.UTF8.GetBytes(messageBody))
            {
                CorrelationId = @event.AggregateId.ToString(),
                MessageId = @event.AggregateId.ToString(),
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
