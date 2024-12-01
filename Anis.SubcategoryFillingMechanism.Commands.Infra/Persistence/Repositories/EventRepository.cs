using Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Repositories;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Events;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace Anis.SubcategoryFillingMechanism.Commands.Infra.Persistence.Repositories
{
    public class EventRepository : AsyncRepository<Event>, IEventRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public EventRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Event>> GetAllByAggregateIdAsync(Guid aggregateId, CancellationToken cancellationToken)
            => await _appDbContext.Events
                                  .AsNoTracking()
                                  .Where(e => e.AggregateId == aggregateId)
                                  .OrderBy(e => e.Sequence)
                                  .ToListAsync(cancellationToken);

        public async Task<IEnumerable<Event>> GetAsPaginationAsync(int currentPage = 1, int pageSize = 2)
        {
            var skip = (currentPage - 1) * pageSize;

            return await _appDbContext.Events
                                      .AsNoTracking()
                                      .OrderBy(e => e.AggregateId)
                                      .ThenBy(e => e.Sequence)
                                      .Skip(skip)
                                      .Take(pageSize)
                                      .ToListAsync();
        }
        public async Task<bool> IsExist(Guid aggregateId, CancellationToken cancellationToken)
            => await _appDbContext.Events
                              .AsNoTracking()
                              .AnyAsync(e => e.AggregateId == aggregateId, cancellationToken);
    }
}
