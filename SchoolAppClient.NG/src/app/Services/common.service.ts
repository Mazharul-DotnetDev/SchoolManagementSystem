import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AcademicMonth } from '../Models/academicmonth';
import { Observable } from 'rxjs';
import { Fee } from '../Models/fee';
import { FeeType } from '../Models/FeeType';

@Injectable({
  providedIn: 'root'
})
export class CommonServices {
  private apiUrl = 'https://localhost:7225/api/';
  private apiUrl2 = 'https://localhost:7225/api/Common/Frequency';
  constructor(private http: HttpClient) { }

  // GET all academic months
  getAllAcademicMonths(): Observable<AcademicMonth[]> {
    const url = `${this.apiUrl}AcademicMonths`;  // Use apiUrl
    return this.http.get<AcademicMonth[]>(url);
  }
  getAllFees(): Observable<Fee[]> {
    const url = `${this.apiUrl}Fees`;
    return this.http.get<Fee[]>(url);
  }

  getAllFeeType(): Observable<FeeType[]> {
    const url = `${this.apiUrl}FeeTypes`;  // Replace with your actual API endpoint
    return this.http.get<FeeType[]>(url);
  }

  getFrequencyEnum(): Observable<string[]> {
    return this.http.get<string[]>(this.apiUrl2);
  }

  getAllStudents(): Observable<any[]> {
    const url = `${this.apiUrl}Students`;  // Replace with your actual API endpoint
    return this.http.get<any[]>(url);
  }

  getAllStandards(): Observable<any[]> {
    const url = `${this.apiUrl}Standards`;  // Replace with your actual API endpoint
    return this.http.get<any[]>(url);
  }

  getDueBalance(studentId: number): Observable<any> {
    return this.http.get(`https://localhost:7225/api/Common/DueBalances/${studentId}`);
  }
}
