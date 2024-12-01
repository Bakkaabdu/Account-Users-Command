using Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Repositories;
using Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Services.BaseServices;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Exceptions;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Models;
using MediatR;

namespace Anis.SubcategoryFillingMechanism.Commands.Application.Features.Commands.DeleteSubcategoryFillingMechanismVideoCommand
{
    public class DeleteSubcategoryFillingMechanismVideoHandler : IRequestHandler<DeleteSubcategoryFillingMechanismVideoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommitEventService _commitEventService;

        public DeleteSubcategoryFillingMechanismVideoHandler(IUnitOfWork unitOfWork, ICommitEventService commitEventService)
        {
            _unitOfWork = unitOfWork;
            _commitEventService = commitEventService;
        }

        public async Task Handle(DeleteSubcategoryFillingMechanismVideoCommand command, CancellationToken cancellationToken)
        {
            var events = await _unitOfWork.Events.GetAllByAggregateIdAsync(command.SubcategoryId, cancellationToken);

            Subcategory subcategory;

            if (!events.Any())
                throw new SubcategoryFillingMechanismHasNotBeenAddedException();

            subcategory = Subcategory.LoadFromHistory(events);
            subcategory.DeleteSubcategoryFillingMechanismVideo(command);

            await _commitEventService.CommitNewEventsAsync(subcategory);
        }
    }
}
