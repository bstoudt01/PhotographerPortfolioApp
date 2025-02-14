import { Component } from '@angular/core';
//import { ImageService } from '../../services/image/image.service'
import { FileUploadComponent } from '../file-upload/file-upload.component';
@Component({
  selector: 'app-admin',
  imports: [FileUploadComponent],
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css'
})

//Create a internal class to use this imageService from constructior?
// class uploadHandler {
//   constructor(private imageService: ImageService) {}
//   getCars(): string[] {
//     return this.cars;
//   }}
export class AdminComponent {
//   imageService: ImageService
// const abc= @new uploadHandler(this.imageService);
//   selectedFile: File | null = null;
//   imageService = 
//   onFileSelected(event: Event): void {
//     const input = event.target as HTMLInputElement;
//     if (input.files && input.files.length > 0) {
//       this.selectedFile = input.files[0];
//     }
//   }
  
}
