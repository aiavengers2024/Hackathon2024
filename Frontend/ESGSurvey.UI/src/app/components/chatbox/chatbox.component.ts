import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
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
  @ViewChild('messageContainer') messageContainer: ElementRef

  constructor(public chatService: ChatboxService) { }

  ngOnInit() {
      this.chatService.conversation.subscribe((val) => {
      this.messages = this.messages.concat(val);
    });
  }
  scrollToBottom() {
      if(this.messageContainer.nativeElement.scrollHeight > this.messageContainer.nativeElement.clientHeight)
        this.messageContainer.nativeElement.scrollTop = this.messageContainer.nativeElement.scrollHeight;
  }

  sendMessage() {
    this.chatService.getopenAIAnswer(this.value);
    this.value = '';
  }

}
