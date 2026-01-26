import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CollegeModel } from '../../../models/college';
import { CollegesService } from '../../../services/colleges';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-college-edit-modal',
  imports: [FormsModule],
  templateUrl: './college-edit-modal.html',
  styleUrl: './college-edit-modal.css',
})
export class CollegeEditModalComponent {
  @Input() college!: CollegeModel;
  @Output() close = new EventEmitter<void>();
  @Output() saved = new EventEmitter<void>();

  constructor(private collegesService: CollegesService) {}

save() {
  this.collegesService.updateCollege({
    id: this.college.collegeId,
    title: this.college.title,
    description: this.college.description,
    logo: this.college.logo,
    sequence: this.college.sequence
  }).subscribe(() => {
    this.saved.emit();
    this.close.emit();
  });
}


}