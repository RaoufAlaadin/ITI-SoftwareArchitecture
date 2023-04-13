import { Component,EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-registeration',
  templateUrl: './registeration.component.html',
  styleUrls: ['./registeration.component.css']
})
export class RegisterationComponent {

  name = "";
  age = "";

  // We want object here not array.
  // Students:{name:string, age:string}[] = [];
  // Student:{name:string, age:string} = { name: "Tamer", age: "25" };


  // StudentData is an alias for `myEvent`
  @Output("StudentData") myEvent = new EventEmitter();

  Fire(){

    let newStudent = {name:this.name, age:this.age};

  // Sends the data out
    console.log("Event got fired");
    console.log(newStudent);

    this.myEvent.emit(newStudent);

  }

}
