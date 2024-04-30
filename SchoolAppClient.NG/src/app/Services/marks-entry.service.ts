import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MarksEntry, StudentMarksDetails } from '../Models/marks-entry';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MarkEntryService {

  private apiBaseUrl = 'https://localhost:7225/api/MarkEntry';

  constructor(private http: HttpClient) { }

  getAllMarkEntries(): Observable<MarksEntry[]> {
    return this.http.get<MarksEntry[]>(`${this.apiBaseUrl}`);
  }

  getMarkEntryById(id: number): Observable<MarksEntry> {
    return this.http.get<MarksEntry>(`${this.apiBaseUrl}/${id}`);
  }

  GetStudents(markEntry: MarksEntry): Observable<StudentMarksDetails[]> {
    return this.http.post<StudentMarksDetails[]>(`${this.apiBaseUrl}/GetStudents`, markEntry);
  }

  createMarkEntry(markEntry: MarksEntry): Observable<MarksEntry> {
    return this.http.post<MarksEntry>(`${this.apiBaseUrl}`, markEntry);
  }

  updateMarkEntry(markEntry: MarksEntry): Observable<MarksEntry> {
    return this.http.put<MarksEntry>(`${this.apiBaseUrl}`, markEntry);
  }

  deleteMarkEntry(id: number): Observable<any> {
    return this.http.delete(`${this.apiBaseUrl}/${id}`);
  }
}
