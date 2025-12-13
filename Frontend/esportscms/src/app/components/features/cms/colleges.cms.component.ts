
import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CollegesService } from '../../../services/colleges';
import { CollegeModel } from '../../../models/college';

@Component({
  selector: 'app-colleges-cms',
  standalone: true,
  imports: [RouterModule, ReactiveFormsModule],
  templateUrl: './colleges.cms.component.html',
  styleUrls: ['./colleges.cms.component.css'],
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

    const college: CollegeModel = this.addCollegeForm.value;

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
