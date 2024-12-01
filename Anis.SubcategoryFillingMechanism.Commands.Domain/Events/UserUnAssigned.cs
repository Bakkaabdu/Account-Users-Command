using Anis.SubcategoryFillingMechanism.Commands.Domain.Events.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anis.SubcategoryFillingMechanism.Commands.Domain.Events
{
    public class UserUnAssigned : Event<UnAssignedUserData>
    {
        public UserUnAssigned(

              Guid aggregateId,
              string userId,
              UnAssignedUserData data,
              int sequence = 1,
              int version = 1
         ) : base(aggregateId, sequence, userId, data, version)

            
        {
            
        }
    }
}
