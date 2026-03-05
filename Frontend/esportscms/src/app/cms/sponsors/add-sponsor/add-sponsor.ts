import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { SponsorsService } from '../../../services/sponsorsService';

@Component({
  selector: 'app-add-sponsor',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './add-sponsor.html',
  styleUrls: ['./add-sponsor.css']

})
export class AddSponsorComponent {
  sponsorForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private sponsorsService: SponsorsService
  ) {
    this.sponsorForm = this.fb.group({
      title: ['', [Validators.required, Validators.maxLength(100)]],
      description: [''],
      sponsorTier: ['Silver', Validators.required],
    });
  }

  submit(): void {
    if (this.sponsorForm.invalid) {
      return;
    }

    this.sponsorsService.addSponsor(this.sponsorForm.value).subscribe({
      next: () => {
        alert('Sponsor added successfully');
        this.sponsorForm.reset({ sponsorTier: 'Silver' });
      },
      error: (err) => {
        console.error(err);
        alert('Failed to add sponsor');
      },
    });
  }
}
