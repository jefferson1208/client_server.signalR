using System.Threading.Tasks;

namespace client_server.signalR.Application.Interfaces
{
    public interface IAppNotificationService
    {
        Task Publish(string message);
    }
}
