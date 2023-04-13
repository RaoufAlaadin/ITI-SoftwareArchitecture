import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent {


  // Sets the logical validation for the form.
  formValidation = new FormGroup({
    name:new FormControl("TamerYoussef",[Validators.required,Validators.minLength(3)]),
    age:new FormControl(25,[Validators.required,Validators.min(20), Validators.max(40)]),
    email:new FormControl("Tamer@gmail.com",[Validators.required,Validators.email])
  })

  // Define getter properties to know the current validation state for the input.
  get NameValid(){
    return this.formValidation.controls["name"].valid
  }


  get AgeValid(){
    return this.formValidation.controls["age"].valid
  }

  get EmailValid(){
    return this.formValidation.controls["email"].valid
  }

  // Component properties
showAlert = false;
formValid = false;
nameValid = false;
ageValid = false;
emailValid = false;

getValue() {
  // for the form in-total => if one of the inputs is not valid, then
  // the total forrm out-put value is `false`.
  this.formValid = this.formValidation.valid;
  console.log("Form: ", this.formValid);

  // per property.
  this.nameValid = this.formValidation.controls["name"].valid;
  console.log("Name: ", this.nameValid);
  this.ageValid = this.formValidation.controls["age"].valid;
  console.log("Age: ", this.ageValid);
  this.emailValid = this.formValidation.controls["email"].valid;
  console.log("Email: ", this.emailValid);

  // Show alert
  this.showAlert = true;
}

/*   getValue(){
    // for the form in-total => if one of the inputs is not valid, then
    // the total forrm out-put value is `false`.
    console.log("Form: ",this.formValidation.valid);

    // per property.
    console.log("Name: ",this.formValidation.controls["name"].valid);
    console.log("Age: ",this.formValidation.controls["age"].valid);
    console.log("Age: ",this.formValidation.controls["email"].valid);

  } */

}
