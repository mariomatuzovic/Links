import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Member } from 'src/app/_models/member';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {
  // members: Member[];
  // here we will take advantage of the async pipe so we can subscribe to this observable
  members$: Observable<Member[]>;

  constructor(private memberService: MembersService) { }

  ngOnInit(): void {
    // this.loadMembers();
    this.members$ = this.memberService.getMembers();
  }

  // loadMembers() {
  //   // we don't need to do any error handling because we have taken care of that inside our error interceptor
  //   this.memberService.getMembers().subscribe(members => {
  //     this.members = members;
  //   });
  // }
}
