using Anis.SubcategoryFillingMechanism.Commands.Domain.Enums;

namespace Anis.SubcategoryFillingMechanism.Commands.Domain.Events.DataTypes
{
    public record SubcategoryFillingMechanismUpdatedData(
        string SubcategoryInfo,
        string EnglishSubcategoryInfo,
        string FillingMechanism,
        string EnglishFillingMechanism) : IEventData
    {
        public EventType Type => EventType.SubcategoryFillingMechanismUpdated;
    }
}
