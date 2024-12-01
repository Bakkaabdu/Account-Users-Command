using Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Repositories;
using Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Services.BaseServices;
using Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Services.ServiceBus;
using Anis.SubcategoryFillingMechanism.Commands.Infra.Persistence;
using Anis.SubcategoryFillingMechanism.Commands.Infra.Persistence.Repositories;
using Anis.SubcategoryFillingMechanism.Commands.Infra.Services.BaseService;
using Anis.SubcategoryFillingMechanism.Commands.Infra.Services.ServiceBus;
using Azure.Messaging.ServiceBus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Anis.SubcategoryFillingMechanism.Commands.Infra
{
    public static class InfraContainer
    {
        public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Database")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IServiceBusPublisher, ServiceBusPublisher>();
            services.AddSingleton<IServiceBusEventSender, ServiceBusEventSender>();

            services.AddSingleton(s =>
            {
                return new ServiceBusClient(configuration.GetConnectionString("ServiceBus"));
            });

            services.AddScoped<ICommitEventService, CommitEventService>();

            return services;
        }
    }
}
