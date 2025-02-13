import { HttpClient, HttpEventType } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
//import { catchError } from 'rxjs/operators';
import { ExtendedFileModel } from '../../components/file-upload/file-upload.component';

@Injectable({
  providedIn: 'root',
})
export class FileUploadService {
  constructor(private httpClient: HttpClient) {}


  uploadFiles(toUploadFile: ExtendedFileModel) {
    const headers = {
      // This is only required for the Mock File Upload service we use here
      // https://www.convertapi.com/doc/upload
      'Content-Disposition': `inline; filename: ${toUploadFile.file.name}`,
      //'Content-Disposition': 'form-data; name="file.name"',

    };
    const formData = new FormData(); 
      formData.append("Photos", toUploadFile.file);
      formData.append('SessionId', toUploadFile.SessionId.toString()); // Example session ID
      formData.append('GalleryId', toUploadFile.GalleryId.toString()); // Example gallery ID
      formData.append('IsPrivate', toUploadFile.IsPrivate.toString()); // Example privacy setting
      formData.append('ClientId', toUploadFile.ClientId.toString()); // Example client ID

      var url = `${toUploadFile.uploadUrl}/api/Photo/AddPhoto`;
    return this.httpClient
      .post(url, formData, {
        headers: headers,
        observe: 'events', // observe and reportProgress options are required to capture the file upload progress
        reportProgress: true,
      })
      .pipe();

      //should i have the error handling in this service? Is it possible? or 
    //  return this.httpClient.post('/api/photo/addphoto', toUploadFile, {
    //     reportProgress: true,
    //     observe: 'events',
    //   }).subscribe(event => {
    //     switch (event.type) {
    //       case HttpEventType.UploadProgress:
    //         console.log('Uploaded ' + event.loaded + ' out of ' + event.total + ' bytes');
    //         break;
    //       case HttpEventType.DownloadProgress:
    //         console.log('Download Progress' + event.type + event.loaded + ' out of ' + event.total + ' bytes');
    //         break;
    //       case HttpEventType.Response:
    //         console.log('Finished uploading!');
    //         break;
    //     }
    //   });

      
      // return this.httpClient.post(url, formData, {
      //       reportProgress: true,
      //       observe: 'events',
      //     }).pipe();
      
  }
}
