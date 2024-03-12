import { Component, OnInit } from '@angular/core';
import { ChatboxService } from '../../services/chatbox.service';
import { Message } from 'src/app/models/Message';

@Component({
  selector: 'app-chatbox',
  templateUrl: './chatbox.component.html',
  styleUrls: ['./chatbox.component.css']
})
export class ChatboxComponent implements OnInit {
  messages: Message[] = [];
  value: string;

  constructor(public chatService: ChatboxService) { }

  ngOnInit() {
      this.chatService.conversation.subscribe((val) => {
      this.messages = this.messages.concat(val);
    });
  }

  sendMessage() {
    this.chatService.getopenAIAnswer(this.value);
    this.value = '';
  }

}
