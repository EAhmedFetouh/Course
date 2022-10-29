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
  constructor(private authService:AuthService , private alertify:AlertifyService) { }

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
      const Token = localStorage.getItem('token');  
      return !! Token;
  }


  LoggedOut (){
    localStorage.removeItem('token');
    this.alertify.message("تم الخروج");
  }

}
