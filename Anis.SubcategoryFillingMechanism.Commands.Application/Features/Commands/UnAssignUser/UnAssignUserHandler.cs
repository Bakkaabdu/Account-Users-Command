using Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Repositories;
using Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Services.BaseServices;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Models;
using MediatR;


namespace Anis.SubcategoryFillingMechanism.Commands.Application.Features.Commands.UnAssignUser
{
    public class UnAssignUserHandler : IRequestHandler<UnAssignUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommitEventService _commitEventService;
        public UnAssignUserHandler(IUnitOfWork unitOfWork, ICommitEventService commitEventService)
        {
            _unitOfWork = unitOfWork;
            _commitEventService = commitEventService;
        }
        public async Task Handle(UnAssignUserCommand request, CancellationToken cancellationToken)
        {
            var events = await _unitOfWork.Events.GetAllByAggregateIdAsync(request.AccountId, cancellationToken);
            Account account;

            if (events.Any())
            {
                account = Account.LoadFromHistory(events);

                account.UnAssignUser(request);

                await _commitEventService.CommitNewEventsAsync(account);
            }
            else
            {
                throw new Exception("Account Not Found");
            }
        }
    }
}
