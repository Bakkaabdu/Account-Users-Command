using Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Services.ServiceBus;
using Anis.SubcategoryFillingMechanism.Commands.Infra.Persistence;
using Anis.SubcategoryFillingMechanism.Commands.Test;
using Anis.SubcategoryFillingMechanism.Commands.Test.Helpers.FakerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
[assembly: CollectionBehavior(DisableTestParallelization = TestConfig.UseSqlDatabase)]
namespace Anis.SubcategoryFillingMechanism.Commands.Test.Helpers
{
    public static class ServiceCollectionExtensions
    {
        public static void SetUnitTestsDefaultEnvironment(this IServiceCollection services)
        {
#pragma warning disable CS0162 // Unreachable code detected
            if (TestConfig.UseSqlDatabase)
                UseSqlDatabaseTesting(services);
            else
                UseInMemoryTesting(services);
#pragma warning restore CS0162 // Unreachable code detected

            RemoveServiceBusLogic(services);
        }

        private static void UseInMemoryTesting(IServiceCollection services)
        {
            var descriptor = services.Single(d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));

            services.Remove(descriptor);

            var dbName = Guid.NewGuid().ToString();

            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase(dbName));
        }


        private static void UseSqlDatabaseTesting(IServiceCollection services)
        {
            var descriptor = services.Single(d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));

            services.Remove(descriptor);

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer("Server=.; Database=anis-subcategory-filling-mechanism-command-test; Integrated Security=true;TrustServerCertificate=True;");
            });

            services.AddHostedService<DbTruncate>();
        }

        private static void RemoveServiceBusLogic(IServiceCollection services)
        {
            var descriptor = services.Single(d => d.ServiceType == typeof(IServiceBusPublisher));
            services.Remove(descriptor);


            services.AddSingleton<IServiceBusPublisher, FakeServiceBusPublisher>();
        }
    }

    public class DbTruncate : IHostedService
    {
        private readonly IServiceProvider _provider;

        public DbTruncate(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var scope = _provider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            await context.Database.MigrateAsync();

            context.RemoveRange(context.OutboxMessages);
            context.RemoveRange(context.Events);
            await context.SaveChangesAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
