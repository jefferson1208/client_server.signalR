using System.Threading.Tasks;

namespace client_server.signalR.Infra.Services
{
    public interface INotify
    {
        Task Publish(string message);
    }
}
