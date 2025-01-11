import { Component } from '@angular/core';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrl: './about.component.css'
})
export class AboutComponent {
  about = {
    title: "Your Photographer",
    description: "Hi, I'm Allie",
    detail: "I am Based on Leavenworth, WA where we have access to all the beauties the North Cascades has to offer. I love to bring the fun and capture everyones personalities.",
    IconBlocks : [
      {
      id:1, 
        icon: "fa-html5",
        title: "Experience", 
        description: "Before living in Beautiful Washington, I started my early career in Golden, CO where I was forunate to capture special moments in the front range and high country for many years!",
      }
      ,{
        id:2, 
        icon: "fa-bolt",
        title: "Past Projects", 
        description: "Portraites, Engagements, Weddings, Special Events, Real Estate, and Landscape"
      }
      ,{
        id:3, 
        icon: "fa-tablet",
        title: "Passions", 
        description: "I love capturing the moments while camping, hiking, snowshoeing, cross-country skiing, and having a good time with friends"
      },
      {
        id:4, 
        icon: "fa-rocket",
        title: "Family", 
        description: "My partner Brett and I married in 2011, we live in Leavenworth with our dog Yoda, who is old and sometimes wise."
      }
    ]
  }
}
