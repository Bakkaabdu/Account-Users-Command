using Anis.SubcategoryFillingMechanism.Commands.Domain.Commands;
using MediatR;

namespace Anis.SubcategoryFillingMechanism.Commands.Application.Features.Commands.UpdateSubcategoryFillingMechanism
{
    public record UpdateSubcategoryFillingMechanismCommand(
        Guid SubcategoryId,
        Guid UserId,
        string SubcategoryInfo,
        string EnglishSubcategoryInfo,
        string FillingMechanism,
        string EnglishFillingMechanism) : IUpdateSubcategoryFillingMechanism, IRequest;
}
