import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FooterComponent } from './components/footer/footer.component';
import { NavComponent } from './components/nav/nav.component';


@Component({
  selector: 'app-root',
  imports: [RouterOutlet, FooterComponent, NavComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  standalone: true
})
export class AppComponent {
  title = 'aStoudtPhotography';
}
