import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_Services/Auth.service';

@Component({
  selector: 'app-Nav',
  templateUrl: './Nav.component.html',
  styleUrls: ['./Nav.component.css']
})
export class NavComponent implements OnInit {

  Model:any={};
  constructor(private authService:AuthService) { }

  ngOnInit() {
  }

  Login(){
    this.authService.Login(this.Model).subscribe(
      next=>{console.log("تم الدخول بنجاح");},
      error=>{console.log("فشل فى الدخول");}
    )
  }

}
