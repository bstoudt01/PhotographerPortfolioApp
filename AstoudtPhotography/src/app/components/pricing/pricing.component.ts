import { Component, NgModule } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-pricing',
  templateUrl: './pricing.component.html',
  styleUrl: './pricing.component.css',
  standalone: true
})

export class PricingComponent {

  //create array of investment category's by id (1 = portaits, 2=engagement, 3=wedding, 4=...)
  //id: 1
  //categoryName: 'portraits'
  //
  //create investment packages for each category (2 column pk)
  //investmentId: 1
  //categoryId: 1
  //photoCount: 15
  //cost: $80
  investments = [
    {
      id: 1,
      investmentType: 'portraits',
    }
  ]

  investmentPackages = [{
    investmentCategoryId: 1,
    investmentId: 1,
    title: 'Small Session',
    description: 'personalized experience for 1-2 people',
    photoCount: '15-20',
    timeline: '3-5 days',
    cost: '80'
  },
    {
      investmentCategoryId: 1,
      investmentId: 2,
      title: 'Fun Session',
      description: '3-4 people and some laughs',
      photoCount: '20-25',
      timeline: '3-5 days',
      cost: '120'
    },
    {
      investmentCategoryId: 1,
      investmentId: 3,
      title: 'Family Session',
      description: 'Capture your familys energy 5-8 people',
      photoCount: '20-25',
      timeline: '3-5 days',
      cost: '160'
    },
    {
      investmentCategoryId: 2,
      investmentId: 1,
      title: 'Small Session',
      description: 'personalized experience',
      photoCount: '15',
      timeline: '5-7 days',
      cost: '80'
    },
    {
      investmentCategoryId: 2,
      investmentId: 1,
      title: 'Small Session',
      description: 'personalized experience',
      photoCount: '15',
      timeline: '3-5 days',
      cost: '80'
    },
    {
      investmentCategoryId: 3,
      investmentId: 1,
      title: 'Small Session',
      description: 'personalized experience',
      photoCount: '15',
      timeline: '3-5 days',
      cost: '80'
    },  ]

  selectedInvestmentPackages: any = this.investmentPackages

  pricingType(category: number) {

    this.selectedInvestmentPackages = this.investmentPackages.filter(x => x.investmentCategoryId == category)
  }

  //pass selectedCategoryId into for loop to get  investment packages related to the category to populate html 

}
