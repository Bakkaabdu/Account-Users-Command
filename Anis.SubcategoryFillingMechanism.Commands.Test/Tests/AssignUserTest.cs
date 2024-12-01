using Anis.SubcategoryFillingMechanism.Commands.Grpc;
using Anis.SubcategoryFillingMechanism.Commands.Test.Helpers;
using Anis.SubcategoryFillingMechanism.Commands.Test.Protos;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Anis.SubcategoryFillingMechanism.Commands.Test.Tests
{
    public class AssignUserTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly DbContextHelper _dbContextHelper;
        private readonly GrpcClientHelper _grpcClientHelper;

        public AssignUserTest(WebApplicationFactory<Program> factory, ITestOutputHelper helper)
        {
            factory = factory.WithDefaultConfigurations(helper, services =>
            {
                services.SetUnitTestsDefaultEnvironment();
            });

            _dbContextHelper = new DbContextHelper(factory.Services);
            _grpcClientHelper = new GrpcClientHelper(factory);
        }

        [Fact]
        public async Task AssignUser_SendValidData_ReturnAssignedSuccessfully()
        {
            // Arrange

            var request = new AssignUserRequest
            {
                AccountId = Guid.NewGuid().ToString(),
                UserId = Guid.NewGuid().ToString()
            };

            // Act
            //var response = await _grpcClientHelper.Send(r => r.
            // Assert
        }
    }
}
