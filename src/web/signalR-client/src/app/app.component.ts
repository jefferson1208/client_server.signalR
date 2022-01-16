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
      console.log('connection started');
    }).catch(err => console.log(err));

    this.hubConnection.on('Streaming', (data) => {
      var date = new Date;
      var time = date.getHours() + ':' + date.getMinutes() + ':' + date.getSeconds();
      this.message = `Data: ${data} Time: ${time}`;
    });

    this.hubConnection.onclose(() => {
      debugger;
      setTimeout(() => {
        console.log('try to re start connection');
        debugger;
        this.hubConnection.start().then(() => {
          debugger;
          console.log('connection re started');
        }).catch(err => console.log(err));
      }, 5000);
    });

  }

  title = 'SignalR - Client';
  message = "Teste SignalR";

  public stopConnection() {
    this.hubConnection.stop().then(() => {
      console.log('stopped');
    }).catch(err => console.log(err));
  }

}
