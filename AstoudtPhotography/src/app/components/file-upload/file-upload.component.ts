
import { Component } from '@angular/core';
import { forkJoin, of } from 'rxjs';
import { HttpEventType, provideHttpClient } from '@angular/common/http';
import { catchError, tap } from 'rxjs/operators';
import { FileUploadService } from '../../services/file/file-upload.service';
import {CommonModule, NgIf} from '@angular/common';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css'],
})
export class FileUploadComponent {
  title = 'Bulk File Upload';

  toUploadFilesList: ExtendedFileModel[] = [];

  constructor(private fileUploadService: FileUploadService) {}

  addFiles(event: Event) {
    this.toUploadFilesList = [];
    const { target } = event;
    const filesList = (target as HTMLInputElement).files;
    if (!filesList) return;
    this.constructToUploadFilesList(filesList);
    this.createImagePreview(filesList);
  }

  uploadFiles(): void {
    const requestsList = this.constructRequestsChain();

    this.executeFileUpload(requestsList);
  }

  private createImagePreview(filesList: FileList): void {
    Array.from(filesList).forEach((item: File) => {
      const reader = new FileReader();
      reader.readAsDataURL(item);
      reader.onload = (event) => {
        const img = new Image();
        img.src = event.target?.result as string;
        const preview = document.getElementById('file-preview');
        if (preview) preview.setAttribute('src', img.src);
      };
      
    });
}

  private constructRequestsChain(): any {
    return this.toUploadFilesList.map((item, index) => {
      return this.fileUploadService.uploadFiles(item).pipe(
        tap((event) => {
          if (event.type === HttpEventType.UploadProgress) {
            this.toUploadFilesList[index].uploadStatus.progressCount =
              Math.round(100 * (event.loaded) / (event.total ?? 1));
          }
        }),
        catchError((error) => {
          return of({ isError: true, index, error });
        })
      );
    });
  }

    // The if conditions were added fround the forEach to avoid the foreach error that was shown in chrome console
  //should i change thises foreach loops to something else to avoid code duplication and make it more readable?
  //map?
  private executeFileUpload(requestsChain: any[]): void {
    if(requestsChain.length > 0 && requestsChain.length < 2){
      requestsChain[0].subscribe((response: any) => {
        if (Array.isArray(response)) {
          response.forEach((item: { isError: any; index: number; error: { statusText: string; }; }) => {
            if (item.isError) {
              this.toUploadFilesList[item.index].uploadStatus.isError = true;
              this.toUploadFilesList[item.index].uploadStatus.errorMessage =
                item.error.statusText;
            }
          });
        }
        else if (response.isError) {
          this.toUploadFilesList[response.index].uploadStatus.isError = true;
          this.toUploadFilesList[response.index].uploadStatus.errorMessage =
          response.error.error[0];
        }
      });
    } 
    else if(requestsChain.length > 1) {
      requestsChain.forEach(element => { 
        element.subscribe((response: any) => {
          if (Array.isArray(response)) {
            response.forEach((item: { isError: any; index: number; error: { statusText: string; }; }) => {
              if (item.isError) {
                this.toUploadFilesList[item.index].uploadStatus.isError = true;
                this.toUploadFilesList[item.index].uploadStatus.errorMessage =
                  item.error.statusText;
              }
            });
          }
          else if (response.isError) {
            this.toUploadFilesList[response.index].uploadStatus.isError = true;
            this.toUploadFilesList[response.index].uploadStatus.errorMessage =
            response.error.error[0];
          }
        });
      });
    }

  }

  private constructToUploadFilesList(filesList: FileList): void {
    Array.from(filesList).forEach((item: File, index: number) => {
      const newFile: ExtendedFileModel = {
        file: item,
        //assign this url in the service or somewhere else?
        uploadUrl:'https://localhost:7183',
        uploadStatus: {
          isSucess: false,
          isError: false,
          errorMessage: '',
          progressCount: 0,
        },
        GalleryId: 1,
        IsPrivate: true,
        ClientId: 2,
        SessionId: 3,

      };
      this.toUploadFilesList.push(newFile);
    });
  }
}

export interface ExtendedFileModel {
  file: File;
  uploadUrl: string;
  uploadStatus: {
    isSucess: boolean;
    isError: boolean;
    errorMessage: string;
    progressCount: number;
  };
  GalleryId: number;
  IsPrivate: boolean;
  ClientId: number;
  SessionId: number;
}



// import { Component } from '@angular/core';
// import { HttpClient, HttpEvent, HttpEventType, HttpRequest } from '@angular/common/http';
// import { last, map, tap } from 'rxjs';

// @Component({
//   selector: 'app-file-upload',
//   templateUrl: './file-upload.component.html'
// })
// export class FileUploadComponent {
//   selectedFile: File | null = null;
//   fileName = '';

//   constructor(private http: HttpClient) {}

//   onFileSelected(event: Event): void {
    
//     const input = event.target as HTMLInputElement;
//     if (input.files && input.files.length > 0) {
//       this.selectedFile = input.files[0];
//     }
    
//   }

//   uploadFile(): void {
//     if (!this.selectedFile) {
//         return;
//     }
//     const formData = new FormData();
//     formData.append('file', this.selectedFile);

//     const req = new HttpRequest('POST', 'https://api.blackhole.io/upload-file', formData, { reportProgress: true });

//     this.http.request(req)
//     .pipe(
//         map((progressEvent) => this.getEventMessage(progressEvent)),
//         tap((progress) => console.log(progress)),
//         last(),
//     )    
//     .subscribe({
//       next: (v) => console.log(v),
//       error: (e) => console.error(e),
//       complete: () => console.info('complete')}
//     );
//   }

//   private getEventMessage(event: HttpEvent<any>) {
//     switch (event.type) {
//         case HttpEventType.UploadProgress:
//             const percentDone = event.total ? Math.round((100 * event.loaded) / event.total) : 0;
//             return percentDone;
//         case HttpEventType.Response:
//             return '100';
//         default:
//             return '';
//     }
//   }
// }