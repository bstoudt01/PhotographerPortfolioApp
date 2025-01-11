import { Component } from '@angular/core';

@Component({
  selector: 'app-footer',
  imports: [],
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.css',
  standalone: true
})
export class FooterComponent {
  footer = {
    copyrightTitle: "Made with love",
    SocialMedia: [
      {
        id: 1,
        title: "Facebook",
        icon: "fa-facebook",
        link: "https://www.facebook.com/username"
      },
      {
        id: 2,
        title: "Google+",
        icon: "fa-google-plus",
        link: "http://google.com/+username"
      },
      {
        id: 3,
        title: "Twitter",
        icon: "fa-twitter",
        link: "http://www.twitter.com/username"
      },
      {
        id: 4,
        title: "Instagram",
        icon: "fa-instagram",
        link: "http://www.instagram.com/username"
      },
      {
        id: 5,
        title: "Behance",
        icon: "fa-behance",
        link: "http://www.behance.net"
      }]
  }
}
