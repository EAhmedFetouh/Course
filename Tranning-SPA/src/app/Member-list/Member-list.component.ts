import { Component, OnInit } from '@angular/core';
import { User } from '../_models/User';
import { AlertifyService } from '../_Services/Alertify.service';
import { UserService } from '../_Services/User.service';

@Component({
  selector: 'app-Member-list',
  templateUrl: './Member-list.component.html',
  styleUrls: ['./Member-list.component.css']
})
export class MemberListComponent implements OnInit {
  users:any;
  constructor(private userservice:UserService , private alertfy:AlertifyService) { }

  ngOnInit() {
    this.loadUsers();
  }

  loadUsers(){
    this.userservice.getUsers().subscribe((users:User[])=>{
        this.users=users
    },
    error=>this.alertfy.error(error)
    
    )
  };

}
