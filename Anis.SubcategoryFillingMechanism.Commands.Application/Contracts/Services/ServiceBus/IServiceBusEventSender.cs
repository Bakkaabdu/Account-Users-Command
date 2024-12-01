using Anis.SubcategoryFillingMechanism.Commands.Domain.Events;

namespace Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Services.ServiceBus
{
    public interface IServiceBusEventSender
    {
        Task SendEventAsync(Event @event);

    }
}
