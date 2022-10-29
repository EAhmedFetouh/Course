import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-Home',
  templateUrl: './Home.component.html',
  styleUrls: ['./Home.component.css']
})
export class HomeComponent implements OnInit {
  RegisterMode:boolean = false;


  constructor(private http:HttpClient) { }

  ngOnInit() {
    
  }

  RegisterToggel()
  {
    this.RegisterMode = true;
  }
  
  CancelRegister(mode:boolean)
  {
    this.RegisterMode = mode;
  }



}
