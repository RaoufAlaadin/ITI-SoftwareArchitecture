import { Component } from '@angular/core';

import {ActivatedRoute} from '@angular/router'


@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styleUrls: ['./student-details.component.css']
})
export class StudentDetailsComponent {
  ID=0;
  constructor(myActivate:ActivatedRoute){
    // console.log(myActivate.snapshot.params["id"]);
    this.ID = myActivate.snapshot.params["id"];
  }

}
