using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace client_server.signalR.Api.SignalR
{
    public class NotificationHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            var connectionId = Context.ConnectionId;
            Clients.Client(connectionId).SendAsync("Streaming", connectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var connectionId = Context.ConnectionId;
            return base.OnDisconnectedAsync(exception);
        }

    }
}
