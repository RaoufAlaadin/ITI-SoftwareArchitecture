import { Component } from '@angular/core';

//Decorator
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',//HTML
  styleUrls: ['./app.component.css']//CSS
})
export class AppComponent {//Logic
  // title = 'demo';
  // DataParent = "2na Data Mn El Parent";
  // DataFromLogin = "";
  // fName = "Ahmed"
  // getData(data:any){
  //   // console.log(data);
  //   this.DataFromLogin = data;
  // }

/*   title = 'demo';
  DataParent = "2na Data Mn El Parent";
  // DataFromLogin = "";
  fName = "Ahmed" */
  DataFromRegisteration : { name: string; age: string } = { name: "", age: "" };
  Students:{name:string, age:string}[] = [];


  getData(data:any){
    // console.log(data);

    console.log("checking the inside of data");

    console.log(data);

    this.DataFromRegisteration = data;
    if(+this.DataFromRegisteration.age <= 50 && +this.DataFromRegisteration.name.length > 3 )
    {
      this.Students.push(this.DataFromRegisteration);

      console.log("data in parent");
    console.log(this.DataFromRegisteration);

      // for somereason clearing the object now,
      // clears the data being sent to the array

      /* In the lecture demo we created another object to store the data in. */

      // this.DataFromRegisteration.name = "";
      // this.DataFromRegisteration.age = "";
    }



  }



  //Logic
}
