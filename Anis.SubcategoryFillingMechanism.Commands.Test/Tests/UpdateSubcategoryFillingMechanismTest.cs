using Anis.SubcategoryFillingMechanism.Commands.Domain.Events;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Events.DataTypes;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Resources;
using Anis.SubcategoryFillingMechanism.Commands.Grpc;
using Anis.SubcategoryFillingMechanism.Commands.Test.Asserts;
using Anis.SubcategoryFillingMechanism.Commands.Test.Fakers;
using Anis.SubcategoryFillingMechanism.Commands.Test.Helpers;
using Calzolari.Grpc.Net.Client.Validation;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;

namespace Anis.SubcategoryFillingMechanism.Commands.Test.Tests
{
    public class UpdateSubcategoryFillingMechanismTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly DbContextHelper _dbContextHelper;
        private readonly GrpcClientHelper _grpcClientHelper;
        public UpdateSubcategoryFillingMechanismTest(WebApplicationFactory<Program> factory, ITestOutputHelper helper)
        {
            factory = factory.WithDefaultConfigurations(helper, services =>
            {
                services.SetUnitTestsDefaultEnvironment();
            });
            _dbContextHelper = new DbContextHelper(factory.Services);
            _grpcClientHelper = new GrpcClientHelper(factory);

        }
        [Fact]
        public async void UpdateSubcategoryFillingMechanism_ToExistingAccount_ReturnSubcategoryFillingMechanismUpdated()
        {

            //Arrange

            var SubcategoryFillingMechanismAddedEvent = new SubcategoryFillingMechanismAddedFaker().Generate();

            await _dbContextHelper.InsertAsync(SubcategoryFillingMechanismAddedEvent);

            var request = new UpdateSubcategoryFillingMechanismRequest
            {
                SubcategoryId = SubcategoryFillingMechanismAddedEvent.AggregateId.ToString(),
                SubcategoryInfo = "hello again",
                FillingMechanism = "new filling"
            };

            //Act
            var response = await _grpcClientHelper.Send(r => r.UpdateSubcategoryFillingMechanismAsync(request, MetadataHelper.GetMetadata()));

            var SubcategoryFillingMechanismUpdatedEvent = await _dbContextHelper.Query(db => db.Events.SingleOrDefaultAsync(s => s.Sequence == 2));

            var outboxMessage = await _dbContextHelper.Query(db => db.OutboxMessages.Include(o => o.Event).SingleOrDefaultAsync());

            //Assert

            Assert.NotNull(SubcategoryFillingMechanismUpdatedEvent);

            Assert.NotNull(outboxMessage);

            Assert.Equal(Phrases.SubcategoryFillingMechanismUpdated, response.Message);

            Assert.Equal(2, SubcategoryFillingMechanismUpdatedEvent.Sequence);

            Assert.Equal(SubcategoryFillingMechanismUpdatedEvent.AggregateId, Guid.Parse(request.SubcategoryId));

            EventsAssert.AssertEquality(request, SubcategoryFillingMechanismUpdatedEvent);

            EventsAssert.AssertEquality<SubcategoryFillingMechanismUpdated, SubcategoryFillingMechanismUpdatedData>(SubcategoryFillingMechanismUpdatedEvent, outboxMessage);
        }

        [Fact]
        public async void UpdateSubcategoryFillingMechanism_ToNotExistingAccount_ThrowSubcategoryFillingMechanismHasNotBeenAddedException()
        {

            //Arrange

            var request = new UpdateSubcategoryFillingMechanismRequest
            {
                SubcategoryId = Guid.NewGuid().ToString(),
                SubcategoryInfo = "hello again",
                FillingMechanism = "new filling"
            };

            //Act
            var exception = await Assert.ThrowsAsync<RpcException>(
                async () => await _grpcClientHelper.Send(r => r.UpdateSubcategoryFillingMechanismAsync(request, MetadataHelper.GetMetadata())));

            var SubcategoryFillingMechanismUpdatedEvent = await _dbContextHelper.Query(db => db.Events.SingleOrDefaultAsync());


            //Assert
            Assert.NotEmpty(exception.Status.Detail);

            Assert.Null(SubcategoryFillingMechanismUpdatedEvent);

            Assert.Equal(Phrases.SubcategoryFillingMechanismHasNotBeenAdded, exception.Status.Detail);


        }

        [Theory]
        [InlineData("28D3BE19-1F24-44E4-8D18", "hello again", "new filling", "SubcategoryId")]
        [InlineData("28D3BE19-1F24-44E4-8D18-D7C09981C198", "", "new filling", "SubcategoryInfo")]
        [InlineData("28D3BE19-1F24-44E4-8D18-D7C09981C195", "hello again", "", "FillingMechanism")]
        public async void UpdateSubcategoryFillingMechanism_SendInvalidData_ThrowInvalidArgumentException
            (string subCategoryId, string subCategoryInfo, string fillingMechanism, string error)
        {

            //Arrange

            var request = new UpdateSubcategoryFillingMechanismRequest
            {
                SubcategoryId = subCategoryId,
                SubcategoryInfo = subCategoryInfo,
                FillingMechanism = fillingMechanism
            };

            //Act
            var exception = await Assert.ThrowsAsync<RpcException>(
                async () => await _grpcClientHelper.Send(r => r.UpdateSubcategoryFillingMechanismAsync(request, MetadataHelper.GetMetadata())));

            var SubcategoryFillingMechanismUpdatedEvent = await _dbContextHelper.Query(db => db.Events.SingleOrDefaultAsync());


            //Assert
            Assert.NotEmpty(exception.Status.Detail);


            Assert.Equal(StatusCode.InvalidArgument, exception.StatusCode);

            Assert.Contains(
                  exception.GetValidationErrors(),
                  e => e.PropertyName.EndsWith(error)
                         );

            Assert.Null(SubcategoryFillingMechanismUpdatedEvent);



        }

    }
}
