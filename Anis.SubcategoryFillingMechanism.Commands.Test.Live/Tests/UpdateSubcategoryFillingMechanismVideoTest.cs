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
    public class UpdateSubcategoryFillingMechanismVideoTest : IClassFixture<WebApplicationFactory<Program>>
    {

        private const int _delay = 20000;
        private readonly GrpcClientHelper _grpcClientHelper;
        private readonly ListenerHelper _listenerHelper;
        private readonly DbContextHelper _dbContextHelper;
        public UpdateSubcategoryFillingMechanismVideoTest(WebApplicationFactory<Program> factory, ITestOutputHelper helper)
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
        public async void UpdateSubcategoryFillingMechanismVideo_ToExistingAccount_ReturnSubcategoryFillingMechanismVideoUpdated()
        {

            //Arrange
            var listener = _listenerHelper.Listener;

            var SubcategoryFillingMechanismAddedEvent = new SubcategoryFillingMechanismAddedFaker().Generate();

            await _dbContextHelper.InsertAsync(SubcategoryFillingMechanismAddedEvent);

            var request = new UpdateSubcategoryFillingMechanismVideoRequest
            {
                SubcategoryId = SubcategoryFillingMechanismAddedEvent.AggregateId.ToString(),
                FillingMechanismVideoUrl = "hello again"
            };

            //Act
            var response = await _grpcClientHelper.Send(r => r.UpdateSubcategoryFillingMechanismVideoAsync(request,MetadataHelper.GetMetadata()));

            await Task.Delay(_delay);

            await listener.CloseAsync();

            var SubcategoryFillingMechanismVideoUpdatedEvent = await _dbContextHelper.Query(db => db.Events.OfType<SubcategoryFillingMechanismVideoUpdated>().SingleOrDefaultAsync(s => s.Sequence == 2));

            var outboxMessage = await _dbContextHelper.Query(db => db.OutboxMessages.Include(o => o.Event).SingleOrDefaultAsync());

            var message = listener.Messages.SingleOrDefault();

            //Assert

            Assert.NotNull(SubcategoryFillingMechanismVideoUpdatedEvent);

            Assert.Equal(Phrases.SubcategoryFillingMechanismVideoUpdated, response.Message);

            Assert.Equal(2, SubcategoryFillingMechanismVideoUpdatedEvent.Sequence);

            Assert.Equal(SubcategoryFillingMechanismVideoUpdatedEvent.AggregateId, Guid.Parse(request.SubcategoryId));

            EventsAssert.AssertEquality(request, SubcategoryFillingMechanismVideoUpdatedEvent);

            MessageAssert.AssertEquality(SubcategoryFillingMechanismVideoUpdatedEvent, message);
        }

    }
}
