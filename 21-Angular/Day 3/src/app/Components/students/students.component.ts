import { Component,Input,OnInit} from '@angular/core';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent implements OnInit {


  @Input("StudentsForm") DataFromParent :{name:string, age:string}[] = [];

  ngOnInit(): void {

  }

print()
{
  console.log("Studentsform Data array.")
    console.log(this.DataFromParent);
}

  // Students:{name:string, age:string}[] = [];
  // add(){


  //   let newStudent = {name:this.DataFromParent.name,
  //     age:this.DataFromParent.age};
  //   if(+this.DataFromParent.age <= 50)
  //   {
  //     this.Students.push(newStudent);
  //     this.DataFromParent.name = "";
  //     this.DataFromParent.age = "";
  //   }
  // }

}
