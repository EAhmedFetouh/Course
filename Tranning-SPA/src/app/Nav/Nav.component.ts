import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../_Services/Alertify.service';
import { AuthService } from '../_Services/Auth.service';

@Component({
  selector: 'app-Nav',
  templateUrl: './Nav.component.html',
  styleUrls: ['./Nav.component.css']
})
export class NavComponent implements OnInit {

  Model:any={};
  username:any;
  constructor(public authService:AuthService , private alertify:AlertifyService) { }

  ngOnInit() {
    
  }

  Login(){
    this.authService.Login(this.Model).subscribe(
      next=>{this.alertify.success("تم تسجيل الدخول بنجاح")},
      error=>{this.alertify.error(error)}
    )
  }
  LoggedIn()
  {
     return  this.authService.LoggedIn();
  }


  LoggedOut (){
    localStorage.removeItem('token');
    this.alertify.message("تم الخروج");
  }

}
