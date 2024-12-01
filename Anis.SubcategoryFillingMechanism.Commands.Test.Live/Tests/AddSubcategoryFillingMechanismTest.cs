using Anis.SubcategoryFillingMechanism.Commands.Domain.Events;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Resources;
using Anis.SubcategoryFillingMechanism.Commands.Grpc;
using Anis.SubcategoryFillingMechanism.Commands.Test.Asserts;
using Anis.SubcategoryFillingMechanism.Commands.Test.Helpers;
using Anis.SubcategoryFillingMechanism.Commands.Test.Live.Asserts;
using Anis.SubcategoryFillingMechanism.Commands.Test.Live.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;

namespace Anis.SubcategoryFillingMechanism.Commands.Test.Live.Tests
{
    public class AddSubcategoryFillingMechanismTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private const int _delay = 10000;
        private readonly DbContextHelper _dbContextHelper;
        private readonly GrpcClientHelper _grpcClientHelper;
        private readonly ListenerHelper _listenerHelper;

        public AddSubcategoryFillingMechanismTest(WebApplicationFactory<Program> factory, ITestOutputHelper helper)
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
        public async Task AddSubcategoryFillingMechanism_ForNotExisitingSubcategory_ReturnValid()
        {
            //Arrange

            var listener = _listenerHelper.Listener;

            var request = new AddSubcategoryFillingMechanismRequest
            {
                SubcategoryId = Guid.NewGuid().ToString(),
                SubcategoryInfo = "This is Subcategory Information",
                FillingMechanism = "This is Filling Mechanism",
                FillingMechanismVideoUrl = null
            };

            //Act

            var response = await _grpcClientHelper.Send(r => r.AddSubcategoryFillingMechanismAsync(request, MetadataHelper.GetMetadata()));

            await Task.Delay(_delay);

            await listener.CloseAsync();

            var @event = await _dbContextHelper.Query(db => db.Events.OfType<SubcategoryFillingMechanismAdded>().SingleOrDefaultAsync());

            var outboxMessage = await _dbContextHelper.Query(db => db.OutboxMessages.Include(o => o.Event).SingleOrDefaultAsync());

            var message = listener.Messages.SingleOrDefault();

            //Assert

            Assert.Null(outboxMessage);

            Assert.Equal(response.Message, Phrases.SubcategoryFillingMechanismAdded);

            EventsAssert.AssertEquality(request, @event);

            MessageAssert.AssertEquality(@event, message);

        }
    }
}
