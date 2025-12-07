import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CollegesService } from '../../../services/colleges';
import { College } from '../../../models/college';

@Component({
  selector: 'app-colleges-cms',
  standalone: true,
  imports: [CommonModule, RouterModule, ReactiveFormsModule],
  templateUrl: './colleges-cms.html',
  styleUrls: ['./colleges-cms.css'],
})
export class CollegesCms {
  addCollegeForm: FormGroup;
  successMessage = '';
  errorMessage = '';

  constructor(
    private router: Router,
    private fb: FormBuilder,
    private collegesService: CollegesService
  ) {
    this.addCollegeForm = this.fb.group({
      title: ['', Validators.required],
      description: ['']
    });
  }

  get isHidden(): boolean {
    return this.router.url !== '/Cms/Colleges';
  }

  submit() {
    if (this.addCollegeForm.invalid) return;

    const college: College = this.addCollegeForm.value;

    this.collegesService.addCollege(college).subscribe({
      next: () => {
        this.successMessage = 'College added successfully!';
        this.errorMessage = '';
        this.addCollegeForm.reset();
      },
      error: () => {
        this.errorMessage = 'Failed to add college.';
        this.successMessage = '';
      },
    });
  }
}
