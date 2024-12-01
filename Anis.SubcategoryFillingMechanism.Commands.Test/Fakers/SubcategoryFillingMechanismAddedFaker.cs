using Anis.SubcategoryFillingMechanism.Commands.Domain.Events;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Events.DataTypes;
using Anis.SubcategoryFillingMechanism.Commands.Test.Fakers;

namespace Anis.SubcategoryFillingMechanism.Commands.Test.Fakers
{
    public class SubcategoryFillingMechanismAddedFaker : CustomConstructorFaker<SubcategoryFillingMechanismAdded>
    {

        public SubcategoryFillingMechanismAddedFaker(Guid? subCategoryId = null)
        {

            RuleFor(r => r.AggregateId, f => subCategoryId ?? f.Random.Guid());
            RuleFor(r => r.UserId, f => f.Random.Guid().ToString());
            RuleFor(r => r.Sequence, 1);
            RuleFor(r => r.Version, 1);
            RuleFor(r => r.DateTime, DateTime.UtcNow);
            RuleFor(r => r.Data, new SubcategoryFillingMechanismAddedDataFaker().Generate());
        }

    }


    public class SubcategoryFillingMechanismAddedDataFaker : CustomConstructorFaker<SubcategoryFillingMechanismAddedData>
    {
       

        public SubcategoryFillingMechanismAddedDataFaker()
        {
            RuleFor(r => r.SubcategoryInfo, f => f.Random.String());
            RuleFor(r => r.FillingMechanism, f => f.Random.String());
            RuleFor(r => r.FillingMechanismVideoUrl, f => f.Random.String());
        }
    }
}