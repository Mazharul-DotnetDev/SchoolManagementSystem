import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Staff } from '../Models/staff';

const baseUrl: string = "https://localhost:7225/api/Staffs";

@Injectable({
  providedIn: 'root'
})
export class StaffService {

  constructor(private http: HttpClient) { }

  getAllStaffs(): Observable<Staff[]> {
    return this.http.get<Staff[]>(baseUrl);
  }

  getStaff(id: number): Observable<Staff> {
    return this.http.get<Staff>(`${baseUrl}/${id}`);
  }

  createStaff(staff: Staff): Observable<Staff> {
    return this.http.post<Staff>(baseUrl, staff);
  }

  updateStaff(id: number, staff: Staff): Observable<Staff> {
    return this.http.put<Staff>(`${baseUrl}/${id}`, staff);
  }

  deleteStaff(id: number): Observable<any> {
    return this.http.delete(`${baseUrl}/${id}`);
  }
}
