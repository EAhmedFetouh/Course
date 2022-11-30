import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { User } from 'src/app/_models/User';
import { AlertifyService } from 'src/app/_Services/Alertify.service';
import { UserService } from 'src/app/_Services/User.service';

@Component({
  selector: 'app-member-deatils',
  templateUrl: './member-deatils.component.html',
  styleUrls: ['./member-deatils.component.css']
})
export class MemberDeatilsComponent implements OnInit {
user:any;
  constructor(private userService:UserService ,private alertify:AlertifyService ,private route:ActivatedRoute) { }

  ngOnInit() {
    this.loadUser();
  }

  loadUser(){
    this.userService.getUser(+this.route.snapshot.params['id']).subscribe(
        (user:User)=>{this.user=user},
        error=>{this.alertify.error(error)}
    )
  }



}
