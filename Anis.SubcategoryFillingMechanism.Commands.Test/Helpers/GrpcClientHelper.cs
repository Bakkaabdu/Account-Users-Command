using Anis.SubcategoryFillingMechanism.Commands.Grpc;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Anis.SubcategoryFillingMechanism.Commands.Test.Helpers
{
    public class GrpcClientHelper
    {
        private readonly WebApplicationFactory<Program> _factory;

        public GrpcClientHelper(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }
        public TResult Send<TResult>(Func<SubcategoryFillingMechanismCommand.SubcategoryFillingMechanismCommandClient, TResult> send)
        {
            var client = new SubcategoryFillingMechanismCommand.SubcategoryFillingMechanismCommandClient(_factory.CreateGrpcChannel());

            return send(client);
        }

    }
}
