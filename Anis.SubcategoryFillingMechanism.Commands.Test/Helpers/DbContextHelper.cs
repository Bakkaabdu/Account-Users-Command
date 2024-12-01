using Anis.SubcategoryFillingMechanism.Commands.Domain.Events;
using Anis.SubcategoryFillingMechanism.Commands.Infra.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Anis.SubcategoryFillingMechanism.Commands.Test.Helpers
{
    public class DbContextHelper
    {
        private readonly IServiceProvider _provider;

        public DbContextHelper(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task<TResult> Query<TResult>(Func<ApplicationDbContext, Task<TResult>> query)
        {
            using var scope = _provider.CreateScope();
            var appDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            return await query(appDbContext);
        }

        public async Task<Event> InsertAsync(Event @event)
        {
            using var scope = _provider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await context.Events.AddAsync(@event);
            await context.SaveChangesAsync();
            return @event;
        }
    }
}
