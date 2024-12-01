using Anis.SubcategoryFillingMechanism.Commands.Domain.Events;
using Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Anis.SubcategoryFillingMechanism.Commands.Grpc.Extensions
{
    public static class ModelExtensions
    {
        public static RepeatedField<EventMessage> ToOutputEvent(this RepeatedField<EventMessage> eventsMessage, IEnumerable<Event> events)
        {
            eventsMessage.AddRange(events.Select(e => new EventMessage
            {
                CorrelationId = e.Id.ToString(),
                DateTime = Timestamp.FromDateTime(DateTime.SpecifyKind(e.DateTime, DateTimeKind.Utc)),
                Data = JsonConvert.SerializeObject(((dynamic)e).Data, new StringEnumConverter()),
                Type = e.Type.ToString(),
                Sequence = e.Sequence,
                Version = e.Version,
                AggredateId = e.AggregateId.ToString(),
                UserId = e.UserId
            }));
            return eventsMessage;
        }

    }
}
