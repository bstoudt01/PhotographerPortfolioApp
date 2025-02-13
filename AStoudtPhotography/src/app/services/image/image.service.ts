import { provideHttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

// class UploadService {
//   // methods to retrieve and return data
// }

//handle image display patterns in this service?
//might just do it per componenet?
export class ImageService {


  // uploadFile(selectedFile: File | null, ): void {
  //   if (!selectedFile) {
  //     return;
  //   }

  //   const formData = new FormData();
  //   formData.append('file', selectedFile);

  //   this.http.post('https://api.blackhole.io/upload-file', formData).subscribe(
  //     response => console.log('File uploaded successfully:', response),
  //     error => console.error('File upload failed:', error)
  //   );
  //}
  
  
  // @Input()
  // requiredFileType:string;

  // fileName = '';
  // uploadProgress:number;
  // uploadSub: Subscription;

  // constructor(private http: HttpClient) {}

  // onFileSelected(event) {
  //     const file:File = event.target.files[0];
    
  //     if (file) {
  //         this.fileName = file.name;
  //         const formData = new FormData();
  //         formData.append("thumbnail", file);

  //         const upload$ = this.http.post("/api/thumbnail-upload", formData, {
  //             reportProgress: true,
  //             observe: 'events'
  //         })
  //         .pipe(
  //             finalize(() => this.reset())
  //         );
        
  //         this.uploadSub = upload$.subscribe(event => {
  //           if (event.type == HttpEventType.UploadProgress) {
  //             this.uploadProgress = Math.round(100 * (event.loaded / event.total));
  //           }
  //         })
  //     }
  // }

  // cancelUpload() {
  //   this.uploadSub.unsubscribe();
  //   this.reset();
  // }

  // reset() {
  //   this.uploadProgress = null;
  //   this.uploadSub = null;
  // }

}
