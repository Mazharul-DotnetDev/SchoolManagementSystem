import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MonthlyPayment } from '../Models/monthly-payment';

@Injectable({
  providedIn: 'root'
})
export class MonthlyPaymentService {
  private apiUrl = 'https://localhost:7225/api/MonthlyPayments';

  constructor(private http: HttpClient) { }

  getAllMonthlyPayments(): Observable<MonthlyPayment[]> {
    return this.http.get<MonthlyPayment[]>(this.apiUrl);
  }

  getMonthlyPaymentById(id: number): Observable<MonthlyPayment> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<MonthlyPayment>(url);
  }

  createMonthlyPayment(monthlyPayment: MonthlyPayment): Observable<MonthlyPayment> {
    return this.http.post<MonthlyPayment>(this.apiUrl, monthlyPayment);
  }
  //updateFee(fee: Fee): Observable<Fee> {
  //  const url = `${this.apiUrl}/${fee.feeId}`;
  //  return this.http.put<Fee>(url, fee);
  //}

  updateMonthlyPayment(monthlyPayment: MonthlyPayment): Observable<MonthlyPayment> {
    const url = `${this.apiUrl}/${monthlyPayment.monthlyPaymentId}`;
    return this.http.put<MonthlyPayment>(url, monthlyPayment);
  }

  deleteMonthlyPayment(id: number): Observable<any> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete(url);
  }
  getMonthlyPaymentDetails(id: number): Observable<MonthlyPayment> {
    const url = `${this.apiUrl}/details/${id}`;
    return this.http.get<MonthlyPayment>(url);
  }
}
