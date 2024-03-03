import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiUrlConstants } from '../common/constants/apiUrl.constants';

@Injectable({
  providedIn: 'root'
})
export class FileUploadService {

  constructor(private http: HttpClient) { }
  
  upload(file: File): Observable<HttpEvent<any>> {
    const formData: FormData = new FormData();

    formData.append('file', file);
    const req = new HttpRequest('POST', ApiUrlConstants.BlobFileUpload, formData, {
      reportProgress: true,
      responseType: 'json'
    });

    return this.http.request(req);
  }

  getFiles(): Observable<any> {
    return this.http.get( ApiUrlConstants.BlobFileList);
  }
}
