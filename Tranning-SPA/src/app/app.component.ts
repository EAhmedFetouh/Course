import { Component , OnInit } from '@angular/core';
import { AuthService } from './_Services/Auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Tranning-SPA';
  jwtHelper= new JwtHelperService();
  constructor(public authservice:AuthService){}
  ngOnInit() {
    const token = localStorage.getItem('token')?.toString();
    this.authservice.decodedTokcken=this.jwtHelper.decodeToken(token);
  } 
  
}
