import { AuthService } from './_Services/Auth.service';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import  {FormsModule} from "@angular/forms"
import { NavComponent } from './Nav/Nav.component';
import { RegisterComponent } from './Register/Register.component';
import { HomeComponent } from './Home/Home.component';
import { ErrorInterceptor } from './_Services/error.interceptor';
import { AlertifyService } from './_Services/Alertify.service';


@NgModule({
  declarations: [		
    AppComponent,
      NavComponent,
      RegisterComponent,
      HomeComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [AuthService,ErrorInterceptor , AlertifyService],
  bootstrap: [AppComponent]
})
export class AppModule { }
