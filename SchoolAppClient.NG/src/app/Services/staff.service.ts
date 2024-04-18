import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Staff } from '../Models/staff';

/*const baseUrl: string = "https://localhost:7225/api/Staffs";*/

@Injectable({
  providedIn: 'root'
})
export class StaffService {
  private apiUrl = 'https://localhost:7225/api/Staffs'; 
    //getAllDepartments: any;
    //getStaffSalaries: any;

  constructor(private http: HttpClient) { }

  // GET all staffs
  getAllStaffs(): Observable<Staff[]> {
    return this.http.get<Staff[]>(this.apiUrl);
  }

  // GET staff by ID
  getStaffById(id: number): Observable<Staff> {
    return this.http.get<Staff>(`${this.apiUrl}/${id}`);
  }

  // POST a new staff
  addStaff(staff: Staff): Observable<Staff> {
    return this.http.post<Staff>(this.apiUrl, staff);
  }

  // PUT update an existing staff
  updateStaff(id: number, staff: Staff): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, staff);
  }

  // DELETE a staff
  deleteStaff(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
