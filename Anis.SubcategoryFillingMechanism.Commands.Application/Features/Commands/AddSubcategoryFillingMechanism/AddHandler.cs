using Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Repositories;
using Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Services.BaseServices;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Models;
using MediatR;

namespace Anis.SubcategoryFillingMechanism.Commands.Application.Features.Commands.AddSubcategoryFillingMechanism
{
    public class AddHandler(IUnitOfWork unitOfWork, ICommitEventService commitEventService) : IRequestHandler<AddCommand>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICommitEventService _commitEventService = commitEventService;

        public async Task Handle(AddCommand command, CancellationToken cancellationToken)
        {
            var events = await _unitOfWork.Events.GetAllByAggregateIdAsync(command.SubcategoryId, cancellationToken);

            Subcategory subcategory;

            if (events.Any())
            {
                subcategory = Subcategory.LoadFromHistory(events);

                subcategory.ReCreate(command);
            }
            else
                subcategory = Subcategory.Create(command);

            await _commitEventService.CommitNewEventsAsync(subcategory);
        }
    }
}
