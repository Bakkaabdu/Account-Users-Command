using Anis.SubcategoryFillingMechanism.Commands.Domain.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anis.SubcategoryFillingMechanism.Commands.Application.Features.Commands.UpdateSubcategoryFillingMechanismVideo
{
    public record UpdateSubcategoryFillingMechanismVideoCommand(Guid SubcategoryId, Guid UserId, string FillingMechanismVideoUrl) : IRequest, IUpdateSubcategoryFillingMechanismVideo
    {
    }
}
