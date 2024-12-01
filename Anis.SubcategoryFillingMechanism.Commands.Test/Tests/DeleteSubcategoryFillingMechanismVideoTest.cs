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
    public class DeleteSubcategoryFillingMechanismVideoTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly DbContextHelper _dbContextHelper;
        private readonly GrpcClientHelper _grpcClientHelper;

        public DeleteSubcategoryFillingMechanismVideoTest(WebApplicationFactory<Program> factory, ITestOutputHelper helper)
        {
            factory = factory.WithDefaultConfigurations(helper, services =>
            {
                services.SetUnitTestsDefaultEnvironment();
            });
            _dbContextHelper = new DbContextHelper(factory.Services);
            _grpcClientHelper = new GrpcClientHelper(factory);

        }
        [Fact]
        public async void DeleteSubcategoryFillingMechanismVideoDelete_ToExistingAccount_ReturnVideoUrlDeleted()
        {

            //Arrange

            var SubcategoryFillingMechanismAddedEvent = new SubcategoryFillingMechanismAddedFaker().Generate();

            await _dbContextHelper.InsertAsync(SubcategoryFillingMechanismAddedEvent);

            var request = new DeleteSubcategoryFillingMechanismVideoRequest
            {
                SubcategoryId = SubcategoryFillingMechanismAddedEvent.AggregateId.ToString()
            };

            //Act

            var response = await _grpcClientHelper.Send(r => r.DeleteSubcategoryFillingMechanismVideoAsync(request,MetadataHelper.GetMetadata()));

            var SubcategoryFillingMechanismDeletedEvent = await _dbContextHelper.Query(db => db.Events.SingleOrDefaultAsync(s => s.Sequence == 2));

            var outboxMessage = await _dbContextHelper.Query(db => db.OutboxMessages.Include(o => o.Event).SingleOrDefaultAsync());

            //Assert

            Assert.NotNull(SubcategoryFillingMechanismDeletedEvent);

            Assert.NotNull(outboxMessage);

            Assert.Equal(Phrases.VideoUrlDeleted, response.Message);

            Assert.Equal(2, SubcategoryFillingMechanismDeletedEvent.Sequence);

            Assert.Equal(SubcategoryFillingMechanismDeletedEvent.AggregateId, Guid.Parse(request.SubcategoryId));

            EventsAssert.AssertEquality(request, SubcategoryFillingMechanismDeletedEvent);

            EventsAssert.AssertEquality<SubcategoryFillingMechanismVideoDeleted, SubcategoryFillingMechanismVideoDeletedData>(SubcategoryFillingMechanismDeletedEvent, outboxMessage);
        }

        [Fact]
        public async void UpdateSubcategoryFillingMechanismVideoDelete_ToNotExistingAccount_ThrowSubcategoryFillingMechanismVideoHasNotBeenAddedException()
        {

            //Arrange

            var request = new DeleteSubcategoryFillingMechanismVideoRequest
            {
                SubcategoryId = Guid.NewGuid().ToString()
            };

            //Act
            var exception = await Assert.ThrowsAsync<RpcException>(
                async () => await _grpcClientHelper.Send(r => r.DeleteSubcategoryFillingMechanismVideoAsync(request,MetadataHelper.GetMetadata())));

            var SubcategoryFillingMechanismVideoDeletedEvent = await _dbContextHelper.Query(db => db.Events.SingleOrDefaultAsync());


            //Assert
            Assert.NotEmpty(exception.Status.Detail);

            Assert.Null(SubcategoryFillingMechanismVideoDeletedEvent);

            Assert.Equal(Phrases.SubcategoryFillingMechanismHasNotBeenAdded, exception.Status.Detail);


        }

        [Theory]
        [InlineData("28D3BE19-1F24-44E4-8D18", "SubcategoryId")]
        public async void UpdateSubcategoryFillingMechanismVideoDelete_SendInvalidData_ThrowInvalidArgumentException
            (string subCategoryId, string error)
        {

            //Arrange

            var request = new DeleteSubcategoryFillingMechanismVideoRequest
            {
                SubcategoryId = subCategoryId
            };

            //Act
            var exception = await Assert.ThrowsAsync<RpcException>(
                async () => await _grpcClientHelper.Send(r => r.DeleteSubcategoryFillingMechanismVideoAsync(request,MetadataHelper.GetMetadata())));

            var SubcategoryFillingMechanismVideoDeletedEvent = await _dbContextHelper.Query(db => db.Events.SingleOrDefaultAsync());


            //Assert
            Assert.NotEmpty(exception.Status.Detail);


            Assert.Equal(StatusCode.InvalidArgument, exception.StatusCode);

            Assert.Contains(
                  exception.GetValidationErrors(),
                  e => e.PropertyName.EndsWith(error)
                         );

            Assert.Null(SubcategoryFillingMechanismVideoDeletedEvent);



        }

    }
}
