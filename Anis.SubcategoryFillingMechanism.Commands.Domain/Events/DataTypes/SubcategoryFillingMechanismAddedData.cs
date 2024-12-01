using Anis.SubcategoryFillingMechanism.Commands.Domain.Enums;

namespace Anis.SubcategoryFillingMechanism.Commands.Domain.Events.DataTypes
{
    public record SubcategoryFillingMechanismAddedData(
        string SubcategoryInfo,
        string EnglishSubcategoryInfo,
        string FillingMechanism,
        string EnglishFillingMechanism,
        string? FillingMechanismVideoUrl
        ) : IEventData
    {
        public EventType Type => EventType.SubcategoryFillingMechanismAdded;
    }
}
