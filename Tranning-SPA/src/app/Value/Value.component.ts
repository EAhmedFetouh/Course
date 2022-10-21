import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-Value',
  templateUrl: './Value.component.html',
  styleUrls: ['./Value.component.css']
})
export class ValueComponent implements OnInit {
 Values:any;
  constructor(private http:HttpClient) { }

  ngOnInit() {
    this.getValue();
  }


  getValue(){
    this.http.get('http://localhost:5071/api/Values').subscribe(
      response=> {
        this.Values=response;},
        error=>{console.log(error);}
      
    )
  }
}
