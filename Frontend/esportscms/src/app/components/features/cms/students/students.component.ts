import { Component, OnInit } from '@angular/core';
import { StudentModel } from '../../../../models/student';
import { StudentsService } from '../../../../services/students';
import { Router } from '@angular/router';

@Component({
  selector: 'app-students',
  imports: [],
  templateUrl: './students.component.html',
  styleUrl: './students.component.css',
})
export class StudentsComponent implements OnInit {

  students: StudentModel[] = [];

  constructor(
    private studentService: StudentsService,
    private router: Router
  ) {}

  get isHidden(): boolean {
    return this.router.url === '/Cms/Students';
  }

  ngOnInit(): void {
    this.loadStudents();
  }

  loadStudents(): void {
    this.studentService.getStudents()
      .subscribe(students => {
        this.students = students;
      });
  }
}
