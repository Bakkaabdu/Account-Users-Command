using Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Services.ServiceBus;

namespace Anis.SubcategoryFillingMechanism.Commands.Test.Helpers.FakerServices
{
    public class FakeServiceBusPublisher : IServiceBusPublisher
    {
        public void StartPublish()
        {
            return;
        }
    }
}
