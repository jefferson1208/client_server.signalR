using client_server.signalR.Application.Interfaces;
using client_server.signalR.Infra.Services;
using System.Threading.Tasks;

namespace client_server.signalR.Application.Services
{
    public class AppNotificationService : IAppNotificationService
    {
        private readonly INotify _notify;
        public AppNotificationService(INotify notify)
        {
            _notify = notify;
        }
        public async Task Publish(string message)
        {
            await _notify.Publish(message);
        }
    }
}
