import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-Nav',
  templateUrl: './Nav.component.html',
  styleUrls: ['./Nav.component.css']
})
export class NavComponent implements OnInit {
   
  Model:any={};
  constructor() { }

  ngOnInit() {
  }

  Login(){
    console.log(this.Model);
  }

}
