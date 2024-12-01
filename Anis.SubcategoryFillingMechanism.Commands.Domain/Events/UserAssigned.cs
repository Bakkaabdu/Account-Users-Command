using Anis.SubcategoryFillingMechanism.Commands.Domain.Events.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anis.SubcategoryFillingMechanism.Commands.Domain.Events
{
    public class UserAssigned : Event<UserAssignedData>
    {
        public UserAssigned(
             Guid aggregateId,
             string userId,
             UserAssignedData data,
             int sequence = 1,
             int version = 1
            ) : base(aggregateId, sequence, userId, data, version)
        {
            
        }
    }
}
