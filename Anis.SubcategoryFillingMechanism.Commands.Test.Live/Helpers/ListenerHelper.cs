using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Anis.SubcategoryFillingMechanism.Commands.Test.Live.Helpers
{
    public class ListenerHelper
    {
        private readonly IServiceProvider _provider;

        public ListenerHelper(IServiceProvider provider)
        {
            _provider = provider;
        }

        private Listener? _listener;

        public Listener Listener
        {
            get
            {
                if (_listener != null)
                    return _listener;

                return _listener = StartListening() ?? throw new Exception("return _listener");
            }
            private set { _listener = value; }
        }

        private Listener StartListening()
        {
            using var scope = _provider.CreateScope();
            var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
            return new Listener(configuration);
        }

        public async Task EndListening()
        {
            await _listener!.CloseAsync();
        }
    }
}
