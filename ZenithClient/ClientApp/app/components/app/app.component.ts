import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http'
@Component({
  selector: 'app',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(private _httpService: Http) { }
  apiValues: string[] = [];
  title = 'app';
  
  ngOnInit() {
    /*this._httpService.get('/api/values').subscribe(values => {
        this.apiValues = values.json() as string[];
    });*/
  }
}