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
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MemberListComponent } from './Member-list/Member-list.component';
import { ListsComponent } from './Lists/Lists.component';
import { MessagesComponent } from './Messages/Messages.component';
import { AppRoutes } from './routes';
import { RouterModule } from '@angular/router';
import { AuthGuard } from './_Guards/auth.guard';

@NgModule({
  declarations: [					
    AppComponent,
      NavComponent,
      RegisterComponent,
      HomeComponent,
      MemberListComponent,
      ListsComponent,
      MessagesComponent,
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BsDropdownModule.forRoot(),
    BrowserAnimationsModule,
    RouterModule.forRoot(AppRoutes)
  ],
  providers: [AuthService,ErrorInterceptor , AlertifyService, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
