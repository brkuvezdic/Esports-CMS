import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FullCalendarModule } from '@fullcalendar/angular';
import dayGridPlugin from '@fullcalendar/daygrid';
import interactionPlugin from '@fullcalendar/interaction';

import { CalendarService, CalendarEventDto } from '../../../services/calendar.service';
import { CalendarOptions } from '@fullcalendar/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-calendar',
  imports: [CommonModule, FullCalendarModule],
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.css'],
})
export class CalendarComponent implements OnInit {
  events: CalendarEventDto[] = [];
  get isHidden(): boolean {
    return !this.router.url.includes('/Schedule') ;

  }

  calendarOptions: CalendarOptions = {
    plugins: [dayGridPlugin, interactionPlugin],
    initialView: 'dayGridMonth',
    events: [],
    editable: true,
    selectable: true,
    eventClick: this.handleEventClick.bind(this),
    dateClick: this.handleDateClick.bind(this),
  };

  constructor(private calendarService: CalendarService, private router: Router) { }

  ngOnInit(): void {
    this.loadEvents();
  }

  loadEvents(): void {
    this.calendarService.getPublicEvents().subscribe((events) => {
      this.events = events;
      this.calendarOptions.events = events.map((e) => ({
        id: e.id,
        title: e.title,
        start: e.startDate,
        end: e.endDate,
        allDay: e.allDay,
        color: e.colorPrimary || '#1e90ff',
      }));
    });
  }

  handleEventClick(info: any) {
    alert(`Event: ${info.event.title}\nStarts: ${info.event.start}`);
  }

  handleDateClick(info: any) {
    alert(`Clicked on date: ${info.dateStr}`);
  }
}
