import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/_Services/User.service';
import { User } from 'src/app/_models/User';
import { AlertifyService } from 'src/app/_Services/Alertify.service';


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
