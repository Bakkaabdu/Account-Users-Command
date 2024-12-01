using Anis.SubcategoryFillingMechanism.Commands.Domain.Enums;

namespace Anis.SubcategoryFillingMechanism.Commands.Domain.Events.DataTypes
{
    public class SubcategoryFillingMechanismDeletedData : IEventData
    {
        public EventType Type => EventType.SubcategoryFillingMechanismDeleted;
    }
}
