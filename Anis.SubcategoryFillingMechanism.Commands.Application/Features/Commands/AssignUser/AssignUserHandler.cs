using Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Repositories;
using Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Services.BaseServices;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Models;
using MediatR;


namespace Anis.SubcategoryFillingMechanism.Commands.Application.Features.Commands.AssignUser
{
    public class AssignUserHandler : IRequestHandler<AssignUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommitEventService _commitEventService;
        public AssignUserHandler(IUnitOfWork unitOfWork, ICommitEventService commitEventService)
        {
            _unitOfWork = unitOfWork;
            _commitEventService = commitEventService;
        }
        public async Task Handle(AssignUserCommand request, CancellationToken cancellationToken)
        {
            var events = await _unitOfWork.Events.GetAllByAggregateIdAsync(request.AccountId, cancellationToken);
            Account account;

            if (events.Any())
            {
                account = Account.LoadFromHistory(events);

                account.AssignUser(request);
            }
            else
            {
                account = Account.Create(request);
            }

            await _commitEventService.CommitNewEventsAsync(account);
        }
    }
}
