import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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
  constructor(public authService:AuthService , private alertify:AlertifyService , private router:Router) { }

  ngOnInit() {
    
  }

  Login(){
    this.authService.Login(this.Model).subscribe(
      next=>{this.alertify.success("تم تسجيل الدخول بنجاح")  },
      error=>{this.alertify.error(error)},
      ()=>{this.router.navigate(['/members'])}
    )
  }
  
  LoggedIn()
  {
     return  this.authService.LoggedIn();
  }


  LoggedOut (){
    localStorage.removeItem('token');
    this.router.navigate(['']);
    this.alertify.message("تم الخروج");
  }

}
