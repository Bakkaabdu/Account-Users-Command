
using Anis.SubcategoryFillingMechanism.Commands.Domain.Events;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Events.DataTypes;
using Anis.SubcategoryFillingMechanism.Commands.Infra.Services.ServiceBus;
using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System.Text;

namespace Anis.SubcategoryFillingMechanism.Commands.Test.Live.Asserts
{
    public static class MessageAssert
    {
        public static void AssertEquality(
           SubcategoryFillingMechanismAdded? subcategoryFillingMechanismAdded,
           ServiceBusReceivedMessage? serviceBusReceivedMessage)
        {
            Assert.NotNull(subcategoryFillingMechanismAdded);
            Assert.NotNull(serviceBusReceivedMessage);

            var body = JsonConvert.DeserializeObject<MessageBody>(Encoding.UTF8.GetString(serviceBusReceivedMessage?.Body));

            Assert.NotNull(body);
            BaseAssert(subcategoryFillingMechanismAdded, serviceBusReceivedMessage, body);

            var eventData = subcategoryFillingMechanismAdded.Data;

            var messageData = JsonConvert.DeserializeObject<SubcategoryFillingMechanismAddedData>(value: body.Data!.ToString()!);

            Assert.NotNull(messageData);

            Assert.Equal(eventData.SubcategoryInfo, messageData.SubcategoryInfo);
            Assert.Equal(eventData.FillingMechanism, messageData.FillingMechanism);
            Assert.Equal(eventData.FillingMechanismVideoUrl, messageData.FillingMechanismVideoUrl);
            Assert.Equal(eventData.Type, messageData.Type);
        }
        public static void AssertEquality(
           SubcategoryFillingMechanismUpdated? subCategoryFillingMechanismUpdated,
           ServiceBusReceivedMessage? serviceBusReceivedMessage)
        {
            Assert.NotNull(subCategoryFillingMechanismUpdated);
            Assert.NotNull(serviceBusReceivedMessage);

            var body = JsonConvert.DeserializeObject<MessageBody>(Encoding.UTF8.GetString(serviceBusReceivedMessage?.Body));

            Assert.NotNull(body);
            BaseAssert(subCategoryFillingMechanismUpdated, serviceBusReceivedMessage, body);

            var eventData = subCategoryFillingMechanismUpdated.Data;

            var messageData = JsonConvert.DeserializeObject<SubcategoryFillingMechanismUpdatedData>(value: body.Data!.ToString()!);

            Assert.NotNull(messageData);

            Assert.Equal(eventData.SubcategoryInfo, messageData.SubcategoryInfo);
            Assert.Equal(eventData.FillingMechanism, messageData.FillingMechanism);
            Assert.Equal(eventData.Type, messageData.Type);
        }
        
        public static void AssertEquality(
           SubcategoryFillingMechanismVideoUpdated? subCategoryFillingMechanismVideoUpdated,
           ServiceBusReceivedMessage? serviceBusReceivedMessage)
        {
            Assert.NotNull(subCategoryFillingMechanismVideoUpdated);
            Assert.NotNull(serviceBusReceivedMessage);

            var body = JsonConvert.DeserializeObject<MessageBody>(Encoding.UTF8.GetString(serviceBusReceivedMessage?.Body));

            Assert.NotNull(body);
            BaseAssert(subCategoryFillingMechanismVideoUpdated, serviceBusReceivedMessage, body);

            var eventData = subCategoryFillingMechanismVideoUpdated.Data;

            var messageData = JsonConvert.DeserializeObject<SubcategoryFillingMechanismVideoUpdatedData>(value: body.Data!.ToString()!);

            Assert.NotNull(messageData);

            Assert.Equal(eventData.FillingMechanismVideoUrl, messageData.FillingMechanismVideoUrl);
            Assert.Equal(eventData.Type, messageData.Type);
        }

        public static void AssertEquality(
          SubcategoryFillingMechanismVideoDeleted? subCtegoryFillingMechanismVideoDeleted,
          ServiceBusReceivedMessage? serviceBusReceivedMessage)
        {
            Assert.NotNull(subCtegoryFillingMechanismVideoDeleted);
            Assert.NotNull(serviceBusReceivedMessage);

            var body = JsonConvert.DeserializeObject<MessageBody>(Encoding.UTF8.GetString(serviceBusReceivedMessage?.Body));

            Assert.NotNull(body);
            BaseAssert(subCtegoryFillingMechanismVideoDeleted, serviceBusReceivedMessage, body);

            var eventData = subCtegoryFillingMechanismVideoDeleted.Data;

            var messageData = JsonConvert.DeserializeObject<SubcategoryFillingMechanismVideoDeletedData>(value: body.Data!.ToString()!);

            Assert.NotNull(messageData);

            Assert.Equal(eventData.Type, messageData.Type);
        }

        private static void BaseAssert(Event? @event, ServiceBusReceivedMessage? message, MessageBody? body)
        {
            Assert.NotNull(@event);
            Assert.NotNull(message);
            Assert.Equal(@event.Id.ToString(), message.CorrelationId);

            Assert.NotNull(body);
            Assert.NotNull(body.Data);

            Assert.Equal(@event.Sequence, body.Sequence);
            Assert.Equal(@event.Version, body.Version);
            Assert.Equal(@event.Type.ToString(), body.Type);
            Assert.Equal(@event.DateTime, body.DateTime, TimeSpan.FromMinutes(1));
        }
    }
}

