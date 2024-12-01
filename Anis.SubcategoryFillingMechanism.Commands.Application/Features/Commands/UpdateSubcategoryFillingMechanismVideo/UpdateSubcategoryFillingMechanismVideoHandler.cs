using Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Repositories;
using Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Services.BaseServices;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Exceptions;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Models;
using MediatR;

namespace Anis.SubcategoryFillingMechanism.Commands.Application.Features.Commands.UpdateSubcategoryFillingMechanismVideo
{
    public class UpdateSubcategoryFillingMechanismVideoHandler : IRequestHandler<UpdateSubcategoryFillingMechanismVideoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommitEventService _commitEventService;

        public UpdateSubcategoryFillingMechanismVideoHandler(IUnitOfWork unitOfWork, ICommitEventService commitEventService)
        {
            _unitOfWork = unitOfWork;
            _commitEventService = commitEventService;
        }

        public async Task Handle(UpdateSubcategoryFillingMechanismVideoCommand command, CancellationToken cancellationToken)
        {
            var events = await _unitOfWork.Events.GetAllByAggregateIdAsync(command.SubcategoryId, cancellationToken);

            Subcategory subcategory;

            if (!events.Any())
                throw new SubcategoryFillingMechanismHasNotBeenAddedException();

            subcategory = Subcategory.LoadFromHistory(events);
            subcategory.UpdateSubcategoryFillingMechanismVideo(command);
            await _commitEventService.CommitNewEventsAsync(subcategory);
        }
    }
}
