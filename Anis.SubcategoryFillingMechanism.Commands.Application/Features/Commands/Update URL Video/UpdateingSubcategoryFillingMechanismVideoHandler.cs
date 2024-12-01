using Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Repositories;
using Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Services.BaseServices;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Exceptions;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Models;
using MediatR;

namespace Anis.SubcategoryFillingMechanism.Commands.Application.Features.Commands.Update_Video
{
    public class UpdateingSubcategoryFillingMechanismVideoHandler : IRequestHandler<UpdateingSubcategoryFillingMechanismVideoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommitEventService _commitEventService;

        public UpdateingSubcategoryFillingMechanismVideoHandler(IUnitOfWork unitOfWork, ICommitEventService commitEventService)
        {
            _unitOfWork = unitOfWork;
            _commitEventService = commitEventService;
        }

        public async Task Handle(UpdateingSubcategoryFillingMechanismVideoCommand command, CancellationToken cancellationToken)
        {
            var events = await _unitOfWork.Events.GetAllByAggregateIdAsync(command.SubcategoryId, cancellationToken);

            if (!events.Any())
                throw new SubcategoryFillingMechanismHasNotBeenAddedException();

            var subcategory = Subcategory.LoadFromHistory(events);

            subcategory.UpdateSubcategoryFillingMechanismVideo(command);

            await _commitEventService.CommitNewEventsAsync(subcategory);

        }
    }
}
