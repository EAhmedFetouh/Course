import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AlertifyService } from '../_Services/Alertify.service';
import { AuthService } from '../_Services/Auth.service';

@Component({
  selector: 'app-Register',
  templateUrl: './Register.component.html',
  styleUrls: ['./Register.component.css']
})
export class RegisterComponent implements OnInit {

  Model:any={};
   
   @Output () CancelRegister =  new EventEmitter();
  constructor(private authService:AuthService ,private alertify:AlertifyService) { }

  ngOnInit() {
  }

  Register(){
   this.authService.Register(this.Model).subscribe(
    ()=>{this.alertify.success("تم الاشتراك بنجاح")},
    error=>{this.alertify.error(error)}
   );
  }

  Cancel(){
   
    this.CancelRegister.emit(false);
  }

}
