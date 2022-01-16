using client_server.signalR.Domain;
using System.Threading.Tasks;

namespace client_server.signalR.Infra.Services
{
    public class Notify : INotify
    {
        private readonly IStreaming _streaming;

        public Notify(IStreaming streamingHub)
        {
            _streaming = streamingHub;
        }

        public void Dispose()
        {
            _streaming.Dispose();
        }

        public async Task Publish(string message)
        {
            await _streaming.Publish(message);
        }
    }
}
