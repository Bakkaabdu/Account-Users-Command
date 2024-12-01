using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anis.SubcategoryFillingMechanism.Commands.Domain.Commands
{
    public interface IUnAssignedUserCommand
    {
        Guid AccountId { get; }
        Guid UserId { get; }
    }
}
