import { Injectable } from '@angular/core';
import * as io from 'socket.io-client';
import { Observable, Subject } from 'rxjs';
import { Message } from '../models/Message';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ApiUrlConstants } from '../common/constants/apiUrl.constants';


@Injectable({
  providedIn: 'root'
})
export class ChatboxService {
    conversation = new Subject<Message[]>();
  
    constructor(private http: HttpClient) {
    }
  
    getopenAIAnswer(msg: string) {
      const userMessage = new Message('user', msg);  
      this.conversation.next([userMessage]);
      this.getopenAIMessage(msg);
    }
  
    getopenAIMessage(question: string): any{
        const headers = new HttpHeaders({ 'content-type': 'application/json' });
        const body = JSON.stringify(question);
        console.log(body)
        this.http.post(ApiUrlConstants.OpenAIServiceServicesTest + question, { 'headers': headers }).subscribe((response: any) =>{
            const openAIMessage = new Message('openai', response);
            this.conversation.next([openAIMessage]);
        },
        (err) =>{
            const openAIMessage = new Message('openai', "My bad! I couldn't find a response for you.");
            this.conversation.next([openAIMessage]);
        });
    }
}