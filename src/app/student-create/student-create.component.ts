import {  Component, Inject, Optional } from '@angular/core';
import {StudentDataService} from '../services/student-data.service';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-student-create',
  templateUrl: './student-create.component.html',
  styleUrls: ['./student-create.component.css']
})

export class StudentCreateComponent {
  student:any;
  constructor(private studentdata:StudentDataService, @Inject(MAT_DIALOG_DATA) public data: any){
    this.student = data; 
  }
  getStudentData(data:any){
    console.warn(data);
    const student = {
      FirstName: data.firstName,
      LastName: data.lastName,
      Roll: parseInt(data.roll),
      Section: data.section,
      Class: parseInt(data.class),
      MobileNumber: data.mobileNumber,
      FathersName: data.fathersName,
      MothersName: data.mothersName
    };

    const educationDetails = {
      PSCGPA: parseFloat(data.psc),
      PSCPassingYear: parseInt(data.pscPassingYear),
      SSCGPA: parseFloat(data.ssc),
      SSCPassingYear: parseInt(data.sscPassingYear)
    };

    this.studentdata.saveStudents(student, educationDetails).subscribe((result)=>{
      alert("Data Successfully Saved");
    })
  } 
}
