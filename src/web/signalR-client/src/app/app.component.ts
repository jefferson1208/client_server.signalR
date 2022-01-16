import { Component, OnInit } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { HubConnection } from '@aspnet/signalr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
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
