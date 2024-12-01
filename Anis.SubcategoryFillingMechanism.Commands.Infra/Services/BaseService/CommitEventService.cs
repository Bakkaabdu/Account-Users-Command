using Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Repositories;
using Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Services.BaseServices;
using Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Services.ServiceBus;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Entities;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Models;

namespace Anis.SubcategoryFillingMechanism.Commands.Infra.Services.BaseService
{
    public class CommitEventService(IUnitOfWork unitOfWork, IServiceBusPublisher serviceBusPublisher) : ICommitEventService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IServiceBusPublisher _serviceBusPublisher = serviceBusPublisher;

        public async Task CommitNewEventsAsync(Subcategory model)
        {
            var newEvents = model.GetUncommittedEvents();

            await _unitOfWork.Events.AddRangeAsync(newEvents);

            var messages = OutboxMessage.ToManyMessages(newEvents);

            await _unitOfWork.OutboxMessages.AddRangeAsync(messages);

            await _unitOfWork.SaveChangesAsync();

            model.MarkChangesAsCommitted();

            _serviceBusPublisher.StartPublish();
        }

        public async Task CommitNewEventsAsync(Account aggregate)
        {
            var newEvents = aggregate.GetUncommittedEvents();

            await _unitOfWork.Events.AddRangeAsync(newEvents);

            var messages = OutboxMessage.ToManyMessages(newEvents);

            await _unitOfWork.OutboxMessages.AddRangeAsync(messages);

            await _unitOfWork.SaveChangesAsync();

            aggregate.MarkChangesAsCommitted();

            _serviceBusPublisher.StartPublish();
        }
    }
}
