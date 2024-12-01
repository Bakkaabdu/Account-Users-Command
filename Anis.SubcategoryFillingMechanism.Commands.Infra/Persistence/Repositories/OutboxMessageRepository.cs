using Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Repositories;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Anis.SubcategoryFillingMechanism.Commands.Infra.Persistence.Repositories
{
    public class OutboxMessageRepository : AsyncRepository<OutboxMessage>, IOutboxMassegesRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public OutboxMessageRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async override Task<IEnumerable<OutboxMessage>> GetAllAsync()
        {
            return await _appDbContext.OutboxMessages
                                      .Include(o => o.Event)
                                      .ToListAsync();
        }
    }
}
