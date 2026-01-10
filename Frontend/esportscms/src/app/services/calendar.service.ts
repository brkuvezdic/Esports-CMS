import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface CalendarEventDto {
  id: string;
  title: string;
  description?: string;
  startDate: string;
  endDate: string;
  allDay: boolean;
  colorPrimary?: string;
  isPublished: boolean;
}

export interface CreateCalendarEventDto {
  title: string;
  description?: string;
  startDate: string;
  endDate: string;
  allDay: boolean;
  colorPrimary?: string;
  isPublished: boolean;
}

export interface UpdateCalendarEventDto extends CreateCalendarEventDto {
  id: string;
}

@Injectable({
  providedIn: 'root'
})
export class CalendarService {

      private baseUrl = 'https://localhost:7147/';
  
  
  constructor(private http: HttpClient) {}

  getPublicEvents(): Observable<CalendarEventDto[]> {
    
    return this.http.get<CalendarEventDto[]>(`${this.baseUrl}api/CalendarEvents/public`);
  }

  getAllEvents(): Observable<CalendarEventDto[]> {
    return this.http.get<CalendarEventDto[]>(this.baseUrl);
  }

  createEvent(dto: CreateCalendarEventDto): Observable<CalendarEventDto> {
    return this.http.post<CalendarEventDto>(`${this.baseUrl}api/CalendarEvents`, dto);
  }

  updateEvent(dto: UpdateCalendarEventDto): Observable<CalendarEventDto> {
    return this.http.put<CalendarEventDto>(`${this.baseUrl}/${dto.id}`, dto);
  }

  deleteEvent(id: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
