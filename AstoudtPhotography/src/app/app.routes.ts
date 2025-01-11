import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AboutComponent } from './components/about/about.component';
//import { GalleryComponent } from './components/gallery/gallery.component';
import { PricingComponent } from './components/pricing/pricing.component';
import { TestimonialsComponent } from './components/testimonials/testimonials.component';
import { ClientsComponent } from './components/clients/clients.component';
import { ServicesComponent } from './components/services/services.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent},
  { path: 'about', component: AboutComponent },
  //lazy load gallery
  { path: 'gallery', loadComponent: () => import('./components/gallery/gallery.component').then(g => g.GalleryComponent) },
  { path: 'pricing', component: PricingComponent},
  { path: 'testimonials', component: TestimonialsComponent},
  { path: 'clients', component: ClientsComponent},
  { path: 'services', component: ServicesComponent}
    
];
