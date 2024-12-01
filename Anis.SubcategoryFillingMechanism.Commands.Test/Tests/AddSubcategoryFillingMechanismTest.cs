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
    public class AddSubcategoryFillingMechanismTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly DbContextHelper _dbContextHelper;
        private readonly GrpcClientHelper _grpcClientHelper;

        public AddSubcategoryFillingMechanismTest(WebApplicationFactory<Program> factory, ITestOutputHelper testOutputHelper)
        {
            factory = factory.WithDefaultConfigurations(testOutputHelper, services =>
            {
                services.SetUnitTestsDefaultEnvironment();
            });
            _dbContextHelper = new DbContextHelper(factory.Services);
            _grpcClientHelper = new GrpcClientHelper(factory);
        }

        [Fact]
        public async Task AddSubcategoryFillingMechanism_ForNotExisitingSubcategory_ReturnValid()
        {
            //Arrange

            var request = new AddSubcategoryFillingMechanismRequest
            {
                SubcategoryId = Guid.NewGuid().ToString(),
                SubcategoryInfo = "This is Subcategory Information",
                FillingMechanism = "This is Filling Mechanism",
                FillingMechanismVideoUrl = "new Video"
            };

            //Act

            var response = await _grpcClientHelper.Send(r => r.AddSubcategoryFillingMechanismAsync(request, MetadataHelper.GetMetadata()));

            var @event = await _dbContextHelper.Query(db => db.Events.SingleOrDefaultAsync());

            var outboxMessage = await _dbContextHelper.Query(db => db.OutboxMessages.Include(o => o.Event).SingleOrDefaultAsync());

            //Assert

            Assert.NotNull(response);
            Assert.NotNull(outboxMessage);
            Assert.NotNull(@event);
            Assert.Equal(response.Message, Phrases.SubcategoryFillingMechanismAdded);
            Assert.Equal(@event.AggregateId, Guid.Parse(request.SubcategoryId));
            EventsAssert.AssertEquality(request, @event);
            EventsAssert.AssertEquality<SubcategoryFillingMechanismAdded, SubcategoryFillingMechanismAddedData>(@event, outboxMessage);

        }
        [Fact]
        public async Task AddSubcategoryFillingMechanism_ForExisitingSubcategory_ReturnAlreadyExistException()
        {
            //Arrange

            var subcategoryFillingMechanismAdded = new SubcategoryFillingMechanismAddedFaker().Generate();

            await _dbContextHelper.InsertAsync(subcategoryFillingMechanismAdded);

            var request = new AddSubcategoryFillingMechanismRequest
            {
                SubcategoryId = subcategoryFillingMechanismAdded.AggregateId.ToString(),
                SubcategoryInfo = "This is Subcategory Information",
                FillingMechanism = "This is Filling Mechanism",
                FillingMechanismVideoUrl = "new video"
            };

            //Act

            var exception = await Assert.ThrowsAsync<RpcException>(
               async () => await _grpcClientHelper.Send(r => r.AddSubcategoryFillingMechanismAsync(request, MetadataHelper.GetMetadata())));

            var @event = await _dbContextHelper.Query(db => db.Events.SingleOrDefaultAsync());

            //Assert

            Assert.NotEmpty(exception.Status.Detail);
            Assert.Equal(Phrases.SubcategoryFillingMechanismAlreadyAdded, exception.Status.Detail);
            Assert.Equal(StatusCode.AlreadyExists, exception.StatusCode);
            Assert.NotNull(@event);
            Assert.Equal(request.SubcategoryId, @event.AggregateId.ToString());
            Assert.Equal(1, @event.Sequence);
        }

        [Fact]
        public async Task AddSubcategoryFillingMechanism_ForDeletedSubcategory_RecreateSubcategory()
        {
            //Arrange

            var subcategoryFillingMechanismAdded = await _dbContextHelper.InsertAsync(
                new SubcategoryFillingMechanismAddedFaker().Generate());

            var subcategoryFillingMechanismDeleted = await _dbContextHelper.InsertAsync(
                new SubcategoryFillingMechanismDeletedFaker(subcategoryFillingMechanismAdded.AggregateId).Generate());


            var request = new AddSubcategoryFillingMechanismRequest
            {
                SubcategoryId = subcategoryFillingMechanismAdded.AggregateId.ToString(),
                SubcategoryInfo = "This is Subcategory Information",
                FillingMechanism = "This is Filling Mechanism",
                FillingMechanismVideoUrl = "new video"
            };

            //Act

            var response = await _grpcClientHelper.Send(r => r.AddSubcategoryFillingMechanismAsync(request, MetadataHelper.GetMetadata()));

            var @event = await _dbContextHelper.Query(db => db.Events.OfType<SubcategoryFillingMechanismAdded>().SingleOrDefaultAsync(e => e.Sequence == 3));

            var outboxMessage = await _dbContextHelper.Query(db => db.OutboxMessages.Include(o => o.Event).SingleOrDefaultAsync());

            //Assert

            Assert.NotNull(response);
            Assert.NotNull(outboxMessage);
            Assert.NotNull(@event);
            Assert.Equal(response.Message, Phrases.SubcategoryFillingMechanismAdded);
            Assert.Equal(@event.AggregateId, Guid.Parse(request.SubcategoryId));
            EventsAssert.AssertEquality(request, @event);
            EventsAssert.AssertEquality<SubcategoryFillingMechanismAdded, SubcategoryFillingMechanismAddedData>(@event, outboxMessage);
        }


        [Theory]
        [InlineData("28D3BE19-1F24-44E4-8D18", "hello", "hello again", " new info", "SubcategoryId")]
        [InlineData("28D3BE19-1F24-44E4-8D18-D7C09981C195", "", "hello again", " new info", "SubcategoryInfo")]
        [InlineData("28D3BE19-1F24-44E4-8D18-D7C09981C195", "hello", "", " new info", "FillingMechanism")]
        [InlineData("28D3BE19-1F24-44E4-8D18-D7C09981C195", "hello", "hello again", "", "FillingMechanismVideoUrl")]
        public async Task AddSubcategoryFillingMechanism_WithInValidData_Return(string subcategoryId, string subCategoryInfo, string fillingMechanism, string fillingMechanismVideoUrl, string error)
        {
            //Arrange

            var request = new AddSubcategoryFillingMechanismRequest
            {
                SubcategoryId = subcategoryId,
                SubcategoryInfo = subCategoryInfo,
                FillingMechanism = fillingMechanism,
                FillingMechanismVideoUrl = fillingMechanismVideoUrl
            };

            //Act

            var exception = await Assert.ThrowsAsync<RpcException>(
              async () => await _grpcClientHelper.Send(r => r.AddSubcategoryFillingMechanismAsync(request, MetadataHelper.GetMetadata())));

            var @event = await _dbContextHelper.Query(db => db.Events.SingleOrDefaultAsync());

            //Assert

            Assert.NotEmpty(exception.Status.Detail);
            Assert.Equal(StatusCode.InvalidArgument, exception.StatusCode);
            Assert.Contains(
                    exception.GetValidationErrors(),
                    e => e.PropertyName.EndsWith(error)
                           );
            Assert.Null(@event);
        }
    }
}
