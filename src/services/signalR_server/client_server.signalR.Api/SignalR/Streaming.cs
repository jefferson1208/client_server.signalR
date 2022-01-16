using client_server.signalR.Domain;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace client_server.signalR.Api.SignalR
{
    public class Streaming : IStreaming
    {
        private readonly IHubContext<NotificationHub> _context;
        public Streaming(IHubContext<NotificationHub> context)
        {
            _context = context;
        }
        public void Dispose()
        {
            
        }

        public async Task Publish(string message)
        {
            await _context.Clients.All.SendAsync("Streaming", message);
        }
    }
}
