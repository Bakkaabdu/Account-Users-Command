using Anis.SubcategoryFillingMechanism.Commands.Domain.Entities;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Events;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Events.DataTypes;

namespace Anis.SubcategoryFillingMechanism.Commands.Test.Asserts
{
    public static class EventsAssert
    {
        public static void AssertEquality(
       UpdateSubcategoryFillingMechanismRequest request,
       Event? @event)
        {
            Assert.NotNull(@event);

            var eventData = (SubcategoryFillingMechanismUpdated)@event;

            Assert.Equal(request.SubcategoryId, eventData.AggregateId.ToString());
            Assert.Equal(request.SubcategoryInfo, eventData.Data.SubcategoryInfo);
            Assert.Equal(request.FillingMechanism, eventData.Data.FillingMechanism);

        }
        public static void AssertEquality(
       UpdateSubcategoryFillingMechanismVideoRequest request,
       Event? @event)
        {
            Assert.NotNull(@event);

            var eventData = (SubcategoryFillingMechanismVideoUpdated)@event;

            Assert.Equal(request.SubcategoryId, eventData.AggregateId.ToString());
            Assert.Equal(request.FillingMechanismVideoUrl, eventData.Data.FillingMechanismVideoUrl);

        }
        public static void AssertEquality(
       DeleteSubcategoryFillingMechanismVideoRequest request,
       Event? @event)
        {
            Assert.NotNull(@event);

            var eventData = (SubcategoryFillingMechanismVideoDeleted)@event;

            Assert.Equal(request.SubcategoryId, eventData.AggregateId.ToString());

        }

        public static void AssertEquality<T, TData>(
           Event? @event,
           OutboxMessage? message,
           bool assertData = true
        ) where T : Event<TData>
          where TData : IEventData
        {
            Assert.NotNull(@event);
            Assert.NotNull(message);
            Assert.NotNull(message.Event);

            Assert.Equal(@event.Sequence, message.Event.Sequence);
            Assert.Equal(1, message.Event.Version);
            Assert.Equal(@event.Type, message.Event.Type);
            Assert.Equal(@event.DateTime, message.Event.DateTime, precision: TimeSpan.FromMinutes(1));

            if (assertData)
                Assert.Equal(((T)@event).Data, ((T)message.Event).Data);
            Assert.Equal(@event.Id, message.Event.Id);
        }
        public static void AssertEquality(
         AddSubcategoryFillingMechanismRequest request,
          Event? @event)
        {

            Assert.NotNull(@event);
            var eventData = (SubcategoryFillingMechanismAdded)@event;
            Assert.Equal(request.SubcategoryId, eventData.AggregateId.ToString());
            Assert.Equal(request.SubcategoryInfo, eventData.Data.SubcategoryInfo);
            Assert.Equal(request.FillingMechanism, eventData.Data.FillingMechanism);
            Assert.Equal(request.FillingMechanismVideoUrl, eventData.Data.FillingMechanismVideoUrl);
        }


    }


}

