using Anis.SubcategoryFillingMechanism.Commands.Domain.Events.DataTypes;

namespace Anis.SubcategoryFillingMechanism.Commands.Domain.Events
{
    public class SubcategoryFillingMechanismDeleted(
        Guid aggregateId,
        int sequence,
        string userId,
        SubcategoryFillingMechanismDeletedData data,
        int version = 1) : Event<SubcategoryFillingMechanismDeletedData>(aggregateId, sequence, userId, data, version)
    {
    }
}
