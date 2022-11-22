import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../_Services/Auth.service';


@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {


  constructor (private authService:AuthService , private router:Router){}
  canActivate():   boolean  {
    if(this.authService.LoggedIn()){
      return true;
    }
    console.log('يجب تسجيل الدخول اولا');
    this.router.navigate(["/home"]);
    return false;
  }
  
}
