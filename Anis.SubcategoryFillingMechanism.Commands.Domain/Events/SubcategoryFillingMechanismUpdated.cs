using Anis.SubcategoryFillingMechanism.Commands.Domain.Events.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anis.SubcategoryFillingMechanism.Commands.Domain.Events
{
    public class SubcategoryFillingMechanismUpdated : Event<SubcategoryFillingMechanismUpdatedData>
    {
        public SubcategoryFillingMechanismUpdated(Guid aggregateId, int sequence, string userId, SubcategoryFillingMechanismUpdatedData data, int version = 1) : base(aggregateId, sequence, userId, data, version)
        {
        }
    }
}
