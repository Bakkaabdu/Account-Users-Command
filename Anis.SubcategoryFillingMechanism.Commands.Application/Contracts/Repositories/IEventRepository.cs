using Anis.SubcategoryFillingMechanism.Commands.Domain.Events;

namespace Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Repositories
{
    public interface IEventRepository : IAsyncRepository<Event>
    {
        Task<IEnumerable<Event>> GetAllByAggregateIdAsync(Guid aggregateId, CancellationToken cancellationToken);
        Task<IEnumerable<Event>> GetAsPaginationAsync(int currentPage = 1, int pageSize = 100);
        Task<bool> IsExist(Guid aggregateId, CancellationToken cancellationToken);

    }
}
