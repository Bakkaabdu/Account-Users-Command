using Anis.SubcategoryFillingMechanism.Commands.Domain.Events;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Resources;
using Anis.SubcategoryFillingMechanism.Commands.Grpc;
using Anis.SubcategoryFillingMechanism.Commands.Test.Asserts;
using Anis.SubcategoryFillingMechanism.Commands.Test.Fakers;
using Anis.SubcategoryFillingMechanism.Commands.Test.Helpers;
using Anis.SubcategoryFillingMechanism.Commands.Test.Live.Asserts;
using Anis.SubcategoryFillingMechanism.Commands.Test.Live.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;

namespace Anis.SubcategoryFillingMechanism.Commands.Test.Live.Tests
{
    public class UpdateSubcategoryFillingMechanismTest : IClassFixture<WebApplicationFactory<Program>>
    {

        private const int _delay = 20000;
        private readonly GrpcClientHelper _grpcClientHelper;
        private readonly ListenerHelper _listenerHelper;
        private readonly DbContextHelper _dbContextHelper;
        public UpdateSubcategoryFillingMechanismTest(WebApplicationFactory<Program> factory, ITestOutputHelper helper)
        {
            factory = factory.WithDefaultConfigurations(helper, services =>
            {
                services.SetLiveTestsDefaultEnvironment();
            });
            _dbContextHelper = new DbContextHelper(factory.Services);
            _grpcClientHelper = new GrpcClientHelper(factory);
            _listenerHelper = new ListenerHelper(factory.Services);

        }

        [Fact]
        public async void UpdateSubcategoryFillingMechanism_ToExistingAccount_ReturnSubcategoryFillingMechanismUpdated()
        {

            //Arrange
            var listener = _listenerHelper.Listener;

            var SubcategoryFillingMechanismAddedEvent = new SubcategoryFillingMechanismAddedFaker().Generate();

            await _dbContextHelper.InsertAsync(SubcategoryFillingMechanismAddedEvent);

            var request = new UpdateSubcategoryFillingMechanismRequest
            {
                SubcategoryId = SubcategoryFillingMechanismAddedEvent.AggregateId.ToString(),
                SubcategoryInfo = "hello again",
                FillingMechanism = "new filling"
            };

            //Act
            var response = await _grpcClientHelper.Send(r => r.UpdateSubcategoryFillingMechanismAsync(request,MetadataHelper.GetMetadata()));

            await Task.Delay(_delay);

            await listener.CloseAsync();

            var SubcategoryFillingMechanismUpdatedEvent = await _dbContextHelper.Query(db => db.Events.OfType<SubcategoryFillingMechanismUpdated>().SingleOrDefaultAsync(s => s.Sequence == 2));

            var outboxMessage = await _dbContextHelper.Query(db => db.OutboxMessages.Include(o => o.Event).SingleOrDefaultAsync());

            var message = listener.Messages.SingleOrDefault();

            //Assert

            Assert.NotNull(SubcategoryFillingMechanismUpdatedEvent);

            Assert.Null(outboxMessage);

            Assert.Equal(Phrases.SubcategoryFillingMechanismUpdated, response.Message);

            Assert.Equal(2, SubcategoryFillingMechanismUpdatedEvent.Sequence);

            Assert.Equal(SubcategoryFillingMechanismUpdatedEvent.AggregateId, Guid.Parse(request.SubcategoryId));

            EventsAssert.AssertEquality(request, SubcategoryFillingMechanismUpdatedEvent);

            MessageAssert.AssertEquality(SubcategoryFillingMechanismUpdatedEvent, message);
        }

    }
}
