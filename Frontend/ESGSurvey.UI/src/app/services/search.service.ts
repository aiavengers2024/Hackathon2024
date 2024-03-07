import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpEvent, HttpHeaders } from '@angular/common/http';
import { catchError, Observable } from 'rxjs';
import { ApiUrlConstants } from '../common/constants/apiUrl.constants';

@Injectable()
export class SearchService {

  constructor(private http: HttpClient) {
  }
  getAllSearchResult(searchText: string): Observable<any> {
    //const headers = { 'content-type': 'application/json', 'Cache-Control': 'no-cache' };
    const headers = new HttpHeaders({ 'content-type': 'application/json' }) ;
    const body = JSON.stringify(searchText);
    console.log(body)
    return this.http.post(ApiUrlConstants.CognitiveSearchServices+searchText, { 'headers': headers })
  }
  getAllAISearchResult(searchText: string): Observable<any> {
    const headers = new HttpHeaders({ 'content-type': 'application/json' });
    const body = JSON.stringify(searchText);
    console.log(body)
    return this.http.post(ApiUrlConstants.OpenAIServiceServices + searchText, { 'headers': headers })
  }
}
