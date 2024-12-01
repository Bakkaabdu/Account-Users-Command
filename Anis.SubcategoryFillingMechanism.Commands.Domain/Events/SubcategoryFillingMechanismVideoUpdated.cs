using Anis.SubcategoryFillingMechanism.Commands.Domain.Events.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anis.SubcategoryFillingMechanism.Commands.Domain.Events
{
    public class SubcategoryFillingMechanismVideoUpdated : Event<SubcategoryFillingMechanismVideoUpdatedData>
    {
        public SubcategoryFillingMechanismVideoUpdated(Guid aggregateId, int sequence, string userId, SubcategoryFillingMechanismVideoUpdatedData data, int version = 1) : base(aggregateId, sequence, userId, data, version)
        {
        }
    }
}
