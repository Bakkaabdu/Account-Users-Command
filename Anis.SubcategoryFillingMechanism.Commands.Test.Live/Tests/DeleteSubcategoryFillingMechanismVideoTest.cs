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
    public class DeleteSubcategoryFillingMechanismVideoTest : IClassFixture<WebApplicationFactory<Program>>
    {

        private const int _delay = 10000;
        private readonly GrpcClientHelper _grpcClientHelper;
        private readonly ListenerHelper _listenerHelper;
        private readonly DbContextHelper _dbContextHelper;
        public DeleteSubcategoryFillingMechanismVideoTest(WebApplicationFactory<Program> factory, ITestOutputHelper helper)
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
        public async void DeleteSubcategoryFillingMechanismVideoDelete_ToExistingAccount_ReturnVideoUrlDeleted()
        {

            //Arrange

            var listener = _listenerHelper.Listener;

            var SubcategoryFillingMechanismAddedEvent = new SubcategoryFillingMechanismAddedFaker().Generate();

            await _dbContextHelper.InsertAsync(SubcategoryFillingMechanismAddedEvent);

            var request = new DeleteSubcategoryFillingMechanismVideoRequest
            {
                SubcategoryId = SubcategoryFillingMechanismAddedEvent.AggregateId.ToString()
            };

            //Act

            var response = await _grpcClientHelper.Send(r => r.DeleteSubcategoryFillingMechanismVideoAsync(request,MetadataHelper.GetMetadata()));

            await Task.Delay(_delay);

            await listener.CloseAsync();

            var SubcategoryFillingMechanismDeletedEvent = await _dbContextHelper.Query(db => db.Events.OfType<SubcategoryFillingMechanismVideoDeleted>().SingleOrDefaultAsync(s => s.Sequence == 2));

            var outboxMessage = await _dbContextHelper.Query(db => db.OutboxMessages.Include(o => o.Event).SingleOrDefaultAsync());

            var message = listener.Messages.SingleOrDefault();

            //Assert

            Assert.NotNull(SubcategoryFillingMechanismDeletedEvent);

            Assert.Equal(Phrases.VideoUrlDeleted, response.Message);

            Assert.Equal(2, SubcategoryFillingMechanismDeletedEvent.Sequence);

            Assert.Equal(SubcategoryFillingMechanismDeletedEvent.AggregateId, Guid.Parse(request.SubcategoryId));

            EventsAssert.AssertEquality(request, SubcategoryFillingMechanismDeletedEvent);

            MessageAssert.AssertEquality(SubcategoryFillingMechanismDeletedEvent, message);
        }


    }
}
