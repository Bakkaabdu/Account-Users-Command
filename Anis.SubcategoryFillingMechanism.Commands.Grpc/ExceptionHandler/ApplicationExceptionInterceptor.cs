using Anis.SubcategoryFillingMechanism.Commands.Domain.Exceptions.Abstraction.Exceptions;
using Anis.SubcategoryFillingMechanism.Commands.Grpc.Extensions;
using Grpc.Core;
using Grpc.Core.Interceptors;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anis.SubcategoryFillingMechanism.Commands.Grpc.ExceptionHandler
{
    public class ApplicationExceptionInterceptor : Interceptor
    {
        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                return await continuation(request, context);
            }
            catch (Exception e) when (e is IProblemDetailsProvider provider)
            {
                throw HandleProblemDetailsException(provider);
            }
        }

        private static RpcException HandleProblemDetailsException(IProblemDetailsProvider provider)
        {
            var problemDetails = provider.GetProblemDetails();

            return new RpcException(new Status(problemDetails.StatusCode.ToRpcStatuseCode(), problemDetails.Title), [
                new Metadata.Entry("problem-details-bin", GetProblemDetailsBytes(problemDetails))
            ]);
        }

        private static readonly JsonSerializerOptions SerializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };

        public static byte[] GetProblemDetailsBytes(ServiceProblemDetails problemDetails)
        {
            var json = JsonSerializer.Serialize(problemDetails, SerializerOptions);
            return Encoding.UTF8.GetBytes(json);
        }
    }
}
