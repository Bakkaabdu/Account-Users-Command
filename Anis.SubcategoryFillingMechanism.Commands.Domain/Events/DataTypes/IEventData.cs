using Anis.SubcategoryFillingMechanism.Commands.Domain.Enums;
using System.Text.Json.Serialization;

namespace Anis.SubcategoryFillingMechanism.Commands.Domain.Events.DataTypes
{
    public interface IEventData
    {
        [JsonIgnore]
        EventType Type { get; }
    }
}
