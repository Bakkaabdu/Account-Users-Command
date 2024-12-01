using Anis.SubcategoryFillingMechanism.Commands.Domain.Commands;
using MediatR;

namespace Anis.SubcategoryFillingMechanism.Commands.Application.Features.Commands.DeleteSubcategoryFillingMechanism
{
    public record DeleteSubcategoryFillingMechanismCommand(
        Guid SubcategoryId,
        Guid UserId
        ) : IDeleteSubcategoryFillingMechanismCommand, IRequest;
}
