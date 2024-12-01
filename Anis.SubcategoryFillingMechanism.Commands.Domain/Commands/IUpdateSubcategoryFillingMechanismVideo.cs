using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anis.SubcategoryFillingMechanism.Commands.Domain.Commands
{
    public interface IUpdateSubcategoryFillingMechanismVideo
    {
        Guid SubcategoryId { get; }
        Guid UserId { get; }
        string FillingMechanismVideoUrl { get; }
    }
}
