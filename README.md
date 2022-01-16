# Client Server SignalR
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
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

### Imports
```javascript
import { Component, OnInit } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { HubConnection } from '@aspnet/signalr';
```
### AppComponent
```javascript
export class AppComponent implements OnInit {

  private hubConnection: HubConnection;

  ngOnInit(): void {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:44302/notifications').build();

    this.hubConnection.start().then(() => {
      console.log('conexão iniciada');
    }).catch(err => console.log(err));

    this.hubConnection.on('Streaming', (data) => {
      var date = new Date;
      var time = date.getHours() + ':' + date.getMinutes() + ':' + date.getSeconds();
      this.pushMessage(`Data: ${data} Time: ${time}`);
    });

    this.hubConnection.onclose(() => {
      debugger;
      setTimeout(() => {
        console.log('tente reiniciar a conexão');
        debugger;
        this.hubConnection.start().then(() => {
          debugger;
          console.log('conexão reinicializada');
        }).catch(err => console.log(err));
      }, 5000);
    });

  }

  messages = [];
  public stopConnection() {
    this.hubConnection.stop().then(() => {
      console.log('conexão finalizada');
    }).catch(err => console.log(err));
  }

  public clearMessages(): void {
    this.messages = [];
  }

  public pushMessage(message: any): void {
    this.messages.push(message);
  }

}
```
## Tecnologias
<div style="display: inline_block"><br>
  <img align="center" alt="Jeferson-Netcore" height="30" width="40" src="https://github.com/devicons/devicon/blob/master/icons/dotnetcore/dotnetcore-original.svg">
  <img align="center" alt="Jeferson-Csharp" height="30" width="40" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg">
  <img align="center" alt="Jeferson-Angular" height="30" width="40" src="https://github.com/devicons/devicon/blob/master/icons/angularjs/angularjs-original.svg">
  <img align="center" alt="Jeferson-Ts" height="30" width="40" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/typescript/typescript-plain.svg">
</div>
