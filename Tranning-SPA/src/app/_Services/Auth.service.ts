import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  BaseUrl = 'https://localhost:7031/api/auth/';
  constructor(private Http: HttpClient) {}

  Login(Model: any) {
    return this.Http.post(this.BaseUrl + 'Login', Model).pipe(
      map((response: any) => {
        const user = response;
        if (user) {
          localStorage.setItem('token', user.token);
        }
      })
    );
  }

  Register(Model:any){
    return this.Http.post(this.BaseUrl + "Register",Model);
  }
}
