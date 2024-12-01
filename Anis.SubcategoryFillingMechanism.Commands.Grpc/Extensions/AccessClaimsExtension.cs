using Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos;
using Grpc.Core;

namespace Anis.SubcategoryFillingMechanism.Commands.Grpc.Extensions
{
    public static class AccessClaimsExtension
    {
        public static AccessClaims GetRequiredAccessClaims(this ServerCallContext context)
        {
            var accessClaims = context.RequestHeaders.SingleOrDefault(t => t.Key == "access-claims-bin")
                ?? throw new RpcException(new Status(StatusCode.Unauthenticated, "Access claims not found"));

            using var stream = new MemoryStream(accessClaims.ValueBytes);

            return AccessClaims.Parser.ParseFrom(stream);
        }

        public static AccessClaims? GetAccessClaims(this ServerCallContext context)
        {
            var accessClaims = context.RequestHeaders.SingleOrDefault(t => t.Key == "access-claims-bin");

            if (accessClaims is null) return null;

            using var stream = new MemoryStream(accessClaims.ValueBytes);

            return AccessClaims.Parser.ParseFrom(stream);
        }
    }
}
