using System.Text.Json.Serialization;

namespace Anis.SubcategoryFillingMechanism.Commands.Domain.Exceptions.Abstraction.Exceptions
{
    public class ServiceProblemDetails
    {
        public required string Title { get; init; }
        public required string Type { get; init; }
        public string? Detail { get; init; }
        public string? Instance { get; init; }
        public IDictionary<string, object?> Extensions { get; init; } = new Dictionary<string, object?>(StringComparer.Ordinal);

        [JsonIgnore]
        public ExceptionStatusCode StatusCode { get; init; }
    }
}
