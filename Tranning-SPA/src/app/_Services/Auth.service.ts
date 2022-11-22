import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  jwtHelper= new JwtHelperService();
  BaseUrl = 'https://localhost:44307/api/auth/';
  decodedTokcken :any;
  constructor(private Http: HttpClient) {}

  Login(Model: any) {
    return this.Http.post(this.BaseUrl + 'Login', Model).pipe(
      map((response: any) => {
        const user = response;
        if (user) {
          localStorage.setItem('token', user.token);
          this.decodedTokcken=this.jwtHelper.decodeToken(user.token);
          console.log(this.decodedTokcken);
        }
      })
    );
  }

  Register(Model:any)
  {
    return this.Http.post(this.BaseUrl + "Register",Model);
  }

  LoggedIn()
  {
    try{
    const token=localStorage.getItem('token')?.toString();
    return ! this.jwtHelper.isTokenExpired(token);
    }
    catch{
      return false;
    }
  }
}
