import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { FirstComponent } from './Components/first/first.component';
import { SecondComponent } from './Components/second/second.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AllInOneComponent } from './Components/Day3/all-in-one/all-in-one.component';
import { HomeComponent } from './Components/Day3/ComponentInteraction/home/home.component';
import { LoginComponent } from './Components/Day3/ComponentInteraction/login/login.component';
import { RegistrationComponent } from './Components/Day4/ComponentInteraction/registration/registration.component';
import { StudentsComponent } from './Components/Day4/ComponentInteraction/students/students.component';
import { ValidationComponent } from './Components/Day4/validation/validation.component';
import { UsersComponent } from './Components/Day4/Routing/users/users.component';
import { UserDetailsComponent } from './Components/Day4/Routing/user-details/user-details.component';
import { ProfileComponent } from './Components/Day4/Routing/profile/profile.component';
import { ErrorComponent } from './Components/Day4/Routing/error/error.component';
import { HeaderComponent } from './Components/Day4/Routing/header/header.component';
import { RouterModule } from '@angular/router';
import { StudentComponent } from './Components/Task4/student/student.component';
import { StudentDetailsComponent } from './Components/Task4/student-details/student-details.component';
import { ErrorPageComponent } from './Components/Task4/error-page/error-page.component';
import { HomePageComponent } from './Components/Task4/home-page/home-page.component';
import { NavbarComponent } from './Components/Task4/navbar/navbar.component';
import { FooterComponent } from './Components/Task4/footer/footer.component';


//Decorator
@NgModule({
  declarations: [
    AppComponent,
    FirstComponent,
    SecondComponent,
    AllInOneComponent,
    HomeComponent,
    LoginComponent,
    RegistrationComponent,
    StudentsComponent,
    ValidationComponent,
    UsersComponent,
    UserDetailsComponent,
    ProfileComponent,
    ErrorComponent,
    HeaderComponent,
    StudentComponent,
    StudentDetailsComponent,
    ErrorPageComponent,
    HomePageComponent,
    NavbarComponent,
    FooterComponent
    /**
     * 1- Components
     * 2- Pipes
     * 3- Directives
     */
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    // RouterModule.forRoot([
    //   {path:"",component:UsersComponent},
    //   {path:"users",component:UsersComponent},
    //   {path:"users/:id",component:UserDetailsComponent},
    //   {path:"profile",component:ProfileComponent},
    //   {path:"**",component:ErrorComponent},
    // ]),
    RouterModule.forRoot([
      { path: "", component: HomePageComponent },
      { path: 'student', component: StudentComponent },
      { path: 'student/:id', component: StudentDetailsComponent},
      { path: '**', component: ErrorPageComponent }



    ])

    /**
     * 4- External Module [httpClientModule - routerModule - formsModule - ReactiveFormsModule - .....]
     */
  ],
  providers: [
    /**
     * 5- Services
     */
  ],
  bootstrap: [AppComponent /**Parent Component */]
})
export class AppModule { }
