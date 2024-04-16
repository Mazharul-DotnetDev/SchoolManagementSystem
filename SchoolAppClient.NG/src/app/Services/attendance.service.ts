import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Attendance } from '../Models/attendance';
import { AttList } from '../Models/attlist';

@Injectable({
  providedIn: 'root'
})
export class AttendanceService {
  private apiUrl = 'https://localhost:7225/api/Attendances'; 

  constructor(private http: HttpClient) { }

  getAttendances(): Observable<Attendance[]> {
    return this.http.get<Attendance[]>(this.apiUrl);
  }

  getAttendance(id: number): Observable<Attendance> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<Attendance>(url);
  }

  addAttendance(attendance: Attendance): Observable<Attendance> {
    return this.http.post<Attendance>(this.apiUrl, attendance);
  }

  getAttendanceListData(attendance: Attendance): Observable<AttList[]> {
    return this.http.get<AttList[]>(this.apiUrl +"/GetList/"+ attendance.type);
  }
}
