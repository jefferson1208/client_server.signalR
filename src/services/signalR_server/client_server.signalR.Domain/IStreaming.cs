using System;
using System.Threading.Tasks;

namespace client_server.signalR.Domain
{
    public interface IStreaming : IDisposable
    {
        Task Publish(string message);
    }
}
