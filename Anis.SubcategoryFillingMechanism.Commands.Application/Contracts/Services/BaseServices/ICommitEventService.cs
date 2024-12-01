using Anis.SubcategoryFillingMechanism.Commands.Domain.Models;

namespace Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Services.BaseServices
{
    public interface ICommitEventService
    {
        Task CommitNewEventsAsync(Account model);
        Task CommitNewEventsAsync(Subcategory subcategory);
    }
}
