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
    public class UpdateSubcategoryFillingMechanismVideoTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly DbContextHelper _dbContextHelper;
        private readonly GrpcClientHelper _grpcClientHelper;
        public UpdateSubcategoryFillingMechanismVideoTest(WebApplicationFactory<Program> factory, ITestOutputHelper helper)
        {
            factory = factory.WithDefaultConfigurations(helper, services =>
            {
                services.SetUnitTestsDefaultEnvironment();
            });
            _dbContextHelper = new DbContextHelper(factory.Services);
            _grpcClientHelper = new GrpcClientHelper(factory);

        }
        [Fact]
        public async void UpdateSubcategoryFillingMechanismVideo_ToExistingAccount_ReturnSubcategoryFillingMechanismVideoUpdated()
        {

            //Arrange

            var SubcategoryFillingMechanismAddedEvent = new SubcategoryFillingMechanismAddedFaker().Generate();

            await _dbContextHelper.InsertAsync(SubcategoryFillingMechanismAddedEvent);

            var request = new UpdateSubcategoryFillingMechanismVideoRequest
            {
                SubcategoryId = SubcategoryFillingMechanismAddedEvent.AggregateId.ToString(),
                FillingMechanismVideoUrl = "hello again"
            };

            //Act
            var response = await _grpcClientHelper.Send(r => r.UpdateSubcategoryFillingMechanismVideoAsync(request, MetadataHelper.GetMetadata()));

            var SubcategoryFillingMechanismVideoUpdatedEvent = await _dbContextHelper.Query(db => db.Events.SingleOrDefaultAsync(s => s.Sequence == 2));

            var outboxMessage = await _dbContextHelper.Query(db => db.OutboxMessages.Include(o => o.Event).SingleOrDefaultAsync());

            //Assert

            Assert.NotNull(SubcategoryFillingMechanismVideoUpdatedEvent);

            Assert.NotNull(outboxMessage);

            Assert.Equal(Phrases.SubcategoryFillingMechanismVideoUpdated, response.Message);

            Assert.Equal(2, SubcategoryFillingMechanismVideoUpdatedEvent.Sequence);

            Assert.Equal(SubcategoryFillingMechanismVideoUpdatedEvent.AggregateId, Guid.Parse(request.SubcategoryId));

            EventsAssert.AssertEquality(request, SubcategoryFillingMechanismVideoUpdatedEvent);

            EventsAssert.AssertEquality<SubcategoryFillingMechanismVideoUpdated, SubcategoryFillingMechanismVideoUpdatedData>(SubcategoryFillingMechanismVideoUpdatedEvent, outboxMessage);
        }

        [Fact]
        public async void UpdateSubcategoryFillingMechanismVideo_ToNotExistingAccount_ThrowSubcategoryFillingMechanismVideoHasNotBeenAddedException()
        {

            //Arrange

            var request = new UpdateSubcategoryFillingMechanismVideoRequest
            {
                SubcategoryId = Guid.NewGuid().ToString(),
                FillingMechanismVideoUrl = "hello again",
            };

            //Act
            var exception = await Assert.ThrowsAsync<RpcException>(
                async () => await _grpcClientHelper.Send(r => r.UpdateSubcategoryFillingMechanismVideoAsync(request, MetadataHelper.GetMetadata())));

            var SubcategoryFillingMechanismVideoUpdatedEvent = await _dbContextHelper.Query(db => db.Events.SingleOrDefaultAsync());


            //Assert
            Assert.NotEmpty(exception.Status.Detail);

            Assert.Null(SubcategoryFillingMechanismVideoUpdatedEvent);

            Assert.Equal(Phrases.SubcategoryFillingMechanismHasNotBeenAdded, exception.Status.Detail);


        }

        [Theory]
        [InlineData("28D3BE19-1F24-44E4-8D18", "hello again", "SubcategoryId")]
        [InlineData("28D3BE19-1F24-44E4-8D18-D7C09981C198", "", "FillingMechanismVideoUrl")]
        public async void UpdateSubcategoryFillingMechanism_SendInvalidData_ThrowInvalidArgumentException
            (string subCategoryId, string fillingMechanismVideoUrl, string error)
        {

            //Arrange

            var request = new UpdateSubcategoryFillingMechanismVideoRequest
            {
                SubcategoryId = subCategoryId,
                FillingMechanismVideoUrl = fillingMechanismVideoUrl
            };

            //Act
            var exception = await Assert.ThrowsAsync<RpcException>(
                async () => await _grpcClientHelper.Send(r => r.UpdateSubcategoryFillingMechanismVideoAsync(request, MetadataHelper.GetMetadata())));

            var SubcategoryFillingMechanismVideoUpdatedEvent = await _dbContextHelper.Query(db => db.Events.SingleOrDefaultAsync());


            //Assert
            Assert.NotEmpty(exception.Status.Detail);


            Assert.Equal(StatusCode.InvalidArgument, exception.StatusCode);

            Assert.Contains(
                  exception.GetValidationErrors(),
                  e => e.PropertyName.EndsWith(error)
                         );

            Assert.Null(SubcategoryFillingMechanismVideoUpdatedEvent);



        }

    }
}
