import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AcademicMonth } from '../Models/academicmonth';
import { BehaviorSubject, Observable } from 'rxjs';
import { Fee } from '../Models/fee';
import { FeeType } from '../Models/feetype';
import { DueBalance } from '../Models/due-balance';
import { MonthlyPayment } from '../Models/monthly-payment';
import { OthersPayment } from '../Models/other-payment';

@Injectable({
  providedIn: 'root'
})
export class CommonServices {
  private apiUrl = 'https://localhost:7225/api/';
  private apiUrl3 = 'https://localhost:7225/api/Common';
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

  getDueBalance(studentId: number): Observable<DueBalance> {
    return this.http.get<DueBalance>(`https://localhost:7225/api/Common/DueBalances/${studentId}`);
  }

  getAllPaymentsByStudentId(studentId: number): Observable<MonthlyPayment[]> {
    return this.http.get<MonthlyPayment[]>(`${this.apiUrl3}/GetAllPaymentByStudentId/${studentId}`);
  }

  getAllOtherPaymentsByStudentId(studentId: number): Observable<OthersPayment[]> {
    return this.http.get<OthersPayment[]>(`${this.apiUrl3}/GetAllOtherPaymentByStudentId/${studentId}`);
  }

  getfeePaymentDetailsByStudentId(studentId: number): Observable<any> {
    return this.http.get(`${this.apiUrl3}/GetPaymentDetailsByStudentId/${studentId}`);
  }


  private sidebarVisibilitySubject = new BehaviorSubject<boolean>(true);
  sidebarVisibility$ = this.sidebarVisibilitySubject.asObservable();

  toggleSidebar() {
    this.sidebarVisibilitySubject.next(!this.sidebarVisibilitySubject.value);
  }


}
