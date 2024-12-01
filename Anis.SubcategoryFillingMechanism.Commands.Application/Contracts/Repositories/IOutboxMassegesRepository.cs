using Anis.SubcategoryFillingMechanism.Commands.Domain.Entities;

namespace Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Repositories
{
    public interface IOutboxMassegesRepository : IAsyncRepository<OutboxMessage>
    {
    }
}
