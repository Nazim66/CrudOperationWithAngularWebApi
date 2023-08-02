import { Component, OnInit } from '@angular/core';
import {StudentDataService} from './services/student-data.service';
import {MatTableDataSource } from '@angular/material/table'
import { MatDialog } from '@angular/material/dialog';
import { StudentCreateComponent } from './student-create/student-create.component'; 

export interface Student {
  name: string;
  roll: number;
  class: number;
}


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title = 'my-app';
  students : any;
  student : any;
  dataSource: MatTableDataSource<Student> = new MatTableDataSource<Student>();;
  displayedColumns: string[] = ['name', 'roll', 'class', 'section', 'mobileNumber', 'fathersName', 'mothersName', 'actions'];
  constructor(private studentData:StudentDataService, private dialog: MatDialog)
  {
    studentData.Students().subscribe((data)=>{
      this.students=data;
      this.dataSource.data = this.students;
    });
  }

  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  onEdit(student: any) {
    // console.warn(student);
    // this.dialog.open(StudentCreateComponent, {
    //   width: '800px', 
    //   data: student
    // });
    // this.student = student;
  }

  onDelete(student: any) {
    const studentId = student.id;
    this.studentData.deleteStudent(studentId).subscribe((result)=>{
      alert("Data Successfully Saved");
    })

  }

  openForm(): void {
    this.dialog.open(StudentCreateComponent, {
      width: '800px', 
    });
  }
}

