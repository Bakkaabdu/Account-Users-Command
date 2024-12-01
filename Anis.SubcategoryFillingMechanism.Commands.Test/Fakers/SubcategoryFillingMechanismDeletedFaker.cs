using Anis.SubcategoryFillingMechanism.Commands.Domain.Enums;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Events;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Events.DataTypes;

namespace Anis.SubcategoryFillingMechanism.Commands.Test.Fakers
{
    public class SubcategoryFillingMechanismDeletedFaker : CustomConstructorFaker<SubcategoryFillingMechanismDeleted>
    {

        public SubcategoryFillingMechanismDeletedFaker(Guid? subCategoryId = null)
        {

            RuleFor(r => r.AggregateId, f => subCategoryId ?? f.Random.Guid());
            RuleFor(r => r.UserId, f => f.Random.Guid().ToString());
            RuleFor(r => r.Sequence, 2);
            RuleFor(r => r.Version, 1);
            RuleFor(r => r.Type, EventType.SubcategoryFillingMechanismDeleted);
            RuleFor(r => r.DateTime, DateTime.UtcNow);
            RuleFor(r => r.Data, new SubcategoryFillingMechanismDeletedData());
        }

    }

}
