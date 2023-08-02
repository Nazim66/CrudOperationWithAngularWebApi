import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class StudentDataService {
  url = "https://localhost:44363/api/student/getAll";
  constructor(private http: HttpClient){}

  Students()
  {
    return this.http.get(this.url);
  }
  saveStudents(student: any, educationDetails: any)
  {
    const studentEducationDetails = { student, educationDetails }; 
    console.warn(studentEducationDetails);
    return this.http.post("https://localhost:44363/api/student/create", studentEducationDetails, httpOptions);
  }

  deleteStudent(studentId:any)
  {
    const urlDelete = "https://localhost:44363/api/student/Delete";
    const url = `${urlDelete}/${studentId}`;
    return this.http.delete(url, { observe: 'response' });
  }
}
