# Client Server SignalR
Notificações com SignalR (Server e Client)

## Server (ASP.NET Core 3.1)
### Packages

```bash
Microsoft.AspNetCore.SignalR.Core
Swashbuckle.AspNetCore
```

### Hub

```csharp
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
    
```


### Configuração

### IServiceCollection services
```csharp
services.AddCors(option =>
{
    option.AddPolicy("CorsPolicy", builder =>
        builder.WithOrigins("*", "http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials());
});

services.AddSignalR();

```

### IApplicationBuilder app

```csharp
app.UseCors("CorsPolicy");

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<NotificationHub>("/notifications");
});

```

## Client (Angular)
### Packages

```bash
npm i @aspnet/signalr
```

```javascript
import { Component, OnInit } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { HubConnection } from '@aspnet/signalr';
```
