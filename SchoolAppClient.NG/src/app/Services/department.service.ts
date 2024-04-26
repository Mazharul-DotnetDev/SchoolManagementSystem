import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Department } from '../Models/department';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DepartmentServices {
  private apiUrl = 'https://localhost:7225/api/Departments';

  constructor(private http: HttpClient) { }


  getAllDepartment(): Observable<Department[]> {
    const url = `${this.apiUrl}`;
    return this.http.get<Department[]>(url);
  }
  getDepartmentById(id: number): Observable<Department> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<Department>(url);
  }
  createDepartment(department: Department): Observable<Department> {
    return this.http.post<Department>(this.apiUrl, department);
  }
  updateDepartment(department: Department): Observable<Department> {
    const url = `${this.apiUrl}/${department.departmentId}`;
    return this.http.put<Department>(url, department);

  }

  deleteDepartment(id: number): Observable<Department> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete<Department>(url);
  }
}
