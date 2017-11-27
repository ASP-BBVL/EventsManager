import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http'

@Component({
  selector: 'app-event-calendar',
  templateUrl: './event-calendar.component.html',
  styleUrls: ['./event-calendar.component.css']
})
export class EventCalendarComponent implements OnInit {

  constructor(private _httpService: Http) { }
  
  apiValues: string[] = [];
  current: Date = new Date();
  week : Date[] = []; //week runs from Monday to Sunday
  weekOf : string;

  ngOnInit() {
    this.initWeek(this.current);
    
    //get events
    /*this._httpService.get('/api/values').subscribe(values => {
      this.apiValues = values.json() as string[];
    });*/
  }

  /**
   * Week starts Monday and ends Sunday.
   * @return Date[] array of dates representing the current week.
   */
  initWeek(date : Date) {
    this.week = [];
    let current = this.copyDate(date);
    let diff = date.getDay() - 1;
    if(diff !== 0) {
      if(diff === -1) {
        diff = 6;  //set diff for sunday
      }
      current.setHours(-24 * diff); //reset to monday
    }
    for(let i=0; i<7; i++) {
      this.week.push(this.copyDate(current));
      current.setHours(24); //increment
    }
    let firstofweek = this.week[0];
    this.weekOf = firstofweek.getFullYear() +'/'+firstofweek.getMonth()+'/'+firstofweek.getDate();
  }

  copyDate(date : Date) {
    return new Date(date.getFullYear(), date.getMonth(), date.getDate());
  }

  changeWeek(e : Event):void {
    let element = (e.target as HTMLElement);
    if(element.tagName === 'I') {
      element = element.parentElement !== null ? element.parentElement : element;
    } 
    let id = element.id;
    let next = this.copyDate(this.current);
    if(id.includes("--incr")) {
      next.setHours(7*24);
    } else if(id.includes("--decr")) {
      next.setHours(-7*24);
    } else if(id.includes("--weekof")) {
      next = new Date();
    }else {
      alert("Error changing dates.")
    }
    this.current = next;
    this.initWeek(this.current);
  }
}
