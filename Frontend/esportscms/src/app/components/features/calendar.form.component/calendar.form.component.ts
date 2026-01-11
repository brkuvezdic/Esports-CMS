import { Component, Input } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CalendarService, CreateCalendarEventDto } from './/../../../services/calendar.service';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-calendar-form',
  templateUrl: './calendar.form.component.html',
  imports: [CommonModule, ReactiveFormsModule],
  styleUrls: ['./calendar.form.component.css'],

})
export class CalendarFormComponent {
  @Input() eventData?: any;
  form: FormGroup;
  get isHidden(): boolean {
    return this.router.url !== '/Cms/Schedule';

  }
  constructor(private fb: FormBuilder, private calendarService: CalendarService, private router: Router,
  ) {
    this.form = this.fb.group({
      title: ['', Validators.required],
      description: [''],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required],
      allDay: [false],
      colorPrimary: ['#1e90ff'],
      isPublished: [true],
    });
  }

  submit() {
    if (this.form.invalid) return;

    const dto: CreateCalendarEventDto = this.form.value;

    this.calendarService.createEvent(dto).subscribe((res) => {
      alert('Event created!');
    });
  }
}
