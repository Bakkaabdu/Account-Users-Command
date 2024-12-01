using Anis.SubcategoryFillingMechanism.Commands.Domain.Commands;
using MediatR;


namespace Anis.SubcategoryFillingMechanism.Commands.Application.Features.Commands.AddSubcategoryFillingMechanism
{
    public record AddCommand(
        Guid SubcategoryId,
        Guid UserId,
        string SubcategoryInfo,
        string EnglishSubcategoryInfo,
        string FillingMechanism,
        string EnglishFillingMechanism,
        string? FillingMechanismVideoUrl
        ) : IAddCommand, IRequest
    {

    }
}
