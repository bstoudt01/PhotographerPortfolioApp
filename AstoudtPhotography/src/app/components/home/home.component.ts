import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  home = {
    title: "A Stoudt Photography",
    description: "Capturing your memories for tomorrow",
    url: "Bretts url is a free thing",
    buttonText: "REMEMBER THE DAY FOREVER"
  
  }
}
