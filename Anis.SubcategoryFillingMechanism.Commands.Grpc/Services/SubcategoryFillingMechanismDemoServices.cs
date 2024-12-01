using Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Services.ServiceBus;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Events;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Events.DataTypes;
using Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace Anis.SubcategoryFillingMechanism.Commands.Grpc.Services
{
    public class SubcategoryFillingMechanismDemoServices : SubcategoryFillingMechanismDemoEvents.SubcategoryFillingMechanismDemoEventsBase
    {
        private readonly IServiceBusEventSender _serviceBusEventSender;

        public SubcategoryFillingMechanismDemoServices(IServiceBusEventSender serviceBusEventSender)
        {
            _serviceBusEventSender = serviceBusEventSender;
        }

        public override async Task<Empty> AddSubcategoryFillingMechanism(Protos.AddSubcategoryFillingMechanismRequest request, ServerCallContext context)
        {
            var @event = new SubcategoryFillingMechanismAdded(
               aggregateId: Guid.Parse(request.SubcategoryId),
               sequence: request.Sequence,
               userId: request.UserId,
               data: new SubcategoryFillingMechanismAddedData(
                   request.SubcategoryInfo,
                   request.SubcategoryInfo,
                   request.FillingMechanism,
                   request.FillingMechanism,
                   request.FillingMechanismVideoUrl));

            await _serviceBusEventSender.SendEventAsync(@event);

            return new Empty();
        }
        public override async Task<Empty> UpdateSubcategoryFillingMechanism(Protos.UpdateSubcategoryFillingMechanismRequest request, ServerCallContext context)
        {
            var @event = new SubcategoryFillingMechanismUpdated(
               aggregateId: Guid.Parse(request.SubcategoryId),
               userId: request.UserId,
               data: new SubcategoryFillingMechanismUpdatedData(
                   request.SubcategoryInfo,
                   request.SubcategoryInfo,
                   request.FillingMechanism,
                   request.FillingMechanism),
               sequence: request.Sequence);

            await _serviceBusEventSender.SendEventAsync(@event);

            return new Empty();
        }
        public override async Task<Empty> UpdateSubcategoryFillingMechanismVideo(Protos.UpdateSubcategoryFillingMechanismVideoRequest request, ServerCallContext context)
        {
            var @event = new SubcategoryFillingMechanismVideoUpdated(
               aggregateId: Guid.Parse(request.SubcategoryId),
               userId: request.UserId,
               data: new SubcategoryFillingMechanismVideoUpdatedData(
                   request.FillingMechanismVideoUrl),
               sequence: request.Sequence);

            await _serviceBusEventSender.SendEventAsync(@event);

            return new Empty();
        }
        public override async Task<Empty> DeleteSubcategoryFillingMechanismVideo(Protos.DeleteSubcategoryFillingMechanismVideoRequest request, ServerCallContext context)
        {
            var @event = new SubcategoryFillingMechanismVideoDeleted(
             aggregateId: Guid.Parse(request.SubcategoryId),
               userId: request.UserId,
               data: new SubcategoryFillingMechanismVideoDeletedData(),
               sequence: request.Sequence);

            await _serviceBusEventSender.SendEventAsync(@event);

            return new Empty();
        }
    }
}
