using Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Repositories;
using Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Services.BaseServices;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Exceptions;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Models;
using MediatR;

namespace Anis.SubcategoryFillingMechanism.Commands.Application.Features.Commands.DeleteSubcategoryFillingMechanism
{
    public class DeleteSubcategoryFillingMechanismHandler(IUnitOfWork unitOfWork, ICommitEventService commitEventService) : IRequestHandler<DeleteSubcategoryFillingMechanismCommand>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICommitEventService _commitEventService = commitEventService;

        public async Task Handle(DeleteSubcategoryFillingMechanismCommand command, CancellationToken cancellationToken)
        {
            var events = await _unitOfWork.Events.GetAllByAggregateIdAsync(command.SubcategoryId, cancellationToken);

            if (!events.Any())
                throw new SubcategoryFillingMechanismHasNotBeenAddedException();

            var subcategory = Subcategory.LoadFromHistory(events);

            subcategory.Delete(command);

            await _commitEventService.CommitNewEventsAsync(subcategory);
        }
    }
}
