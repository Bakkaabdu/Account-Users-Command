using Anis.SubcategoryFillingMechanism.Commands.Domain.Events;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Events.DataTypes;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Resources;
using Anis.SubcategoryFillingMechanism.Commands.Grpc;
using Anis.SubcategoryFillingMechanism.Commands.Test.Asserts;
using Anis.SubcategoryFillingMechanism.Commands.Test.Fakers;
using Anis.SubcategoryFillingMechanism.Commands.Test.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;

namespace Anis.SubcategoryFillingMechanism.Commands.Test.Tests
{
    public class DeleteSubcategoryFillingMechanismTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly DbContextHelper _dbContextHelper;
        private readonly GrpcClientHelper _grpcClientHelper;

        public DeleteSubcategoryFillingMechanismTest(WebApplicationFactory<Program> factory, ITestOutputHelper testOutputHelper)
        {
            factory = factory.WithDefaultConfigurations(testOutputHelper, services =>
            {
                services.SetUnitTestsDefaultEnvironment();
            });
            _dbContextHelper = new DbContextHelper(factory.Services);
            _grpcClientHelper = new GrpcClientHelper(factory);
        }

        [Fact]
        public async Task DeleteSubcategoryFillingMechanism_ForExistMechanism_ReturnMechanismDeleted()
        {
            // Arrange

            var subcategoryFillingMechanismAdded = await _dbContextHelper.InsertAsync(
               new SubcategoryFillingMechanismAddedFaker().Generate());

            var request = new DeleteSubcategoryFillingMechanismRequest
            {
                SubcategoryId = subcategoryFillingMechanismAdded.AggregateId.ToString()
            };

            // Act

            var response = await _grpcClientHelper.Send(r => r.DeleteSubcategoryFillingMechanismAsync(request, MetadataHelper.GetMetadata()));

            var @event = await _dbContextHelper.Query(db => db.Events.OfType<SubcategoryFillingMechanismDeleted>().SingleOrDefaultAsync(e => e.Sequence == 2));

            var outboxMessage = await _dbContextHelper.Query(db => db.OutboxMessages.Include(o => o.Event).SingleOrDefaultAsync());


            // Assert
            Assert.NotNull(response);
            Assert.NotNull(outboxMessage);
            Assert.NotNull(@event);
            Assert.Equal(response.Message, Phrases.SubcategoryFillingMechanismDeleted);
            Assert.Equal(@event.AggregateId, Guid.Parse(request.SubcategoryId));
            EventsAssert.AssertEquality<SubcategoryFillingMechanismDeleted, SubcategoryFillingMechanismDeletedData>(@event, outboxMessage, false);
        }
    }
}
