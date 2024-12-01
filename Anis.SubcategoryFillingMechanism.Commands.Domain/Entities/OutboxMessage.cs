﻿using Anis.SubcategoryFillingMechanism.Commands.Domain.Events;

namespace Anis.SubcategoryFillingMechanism.Commands.Domain.Entities
{
    public class OutboxMessage
    {
        public static IEnumerable<OutboxMessage> ToManyMessages(IEnumerable<Event> events)
      => events.Select(e => new OutboxMessage(e));
        private OutboxMessage() { }
        public OutboxMessage(Event @event)
        {
            Event = @event;
        }
        public long Id { get; private set; }
        public Event? Event { get; private set; }
    }
}
