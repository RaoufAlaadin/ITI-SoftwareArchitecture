import { Component } from '@angular/core';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent {

  students = [
    { name: 'Ahmed', age: 20, email: 'ahmed@example.com' },
  { name: 'Fatima', age: 22, email: 'fatima@example.com' },
  { name: 'Hassan', age: 24, email: 'hassan@example.com' },
  { name: 'Layla', age: 26, email: 'layla@example.com' },
  { name: 'Mohammed', age: 28, email: 'mohammed@example.com' },
  { name: 'Nour', age: 30, email: 'nour@example.com' },
  { name: 'Omar', age: 32, email: 'omar@example.com' },
  { name: 'Rania', age: 34, email: 'rania@example.com' },
  { name: 'Sara', age: 36, email: 'sara@example.com' },
  { name: 'Youssef', age: 38, email: 'youssef@example.com' }
  ];

}
