import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Fee } from '../Models/fee';

@Injectable({
  providedIn: 'root'
})
export class FeeService {
  private apiUrl = 'https://localhost:7225/api/Fees';

  constructor(private http: HttpClient) { }

  // Method to fetch all fees
  getAllFees(): Observable<Fee[]> {
    return this.http.get<Fee[]>(this.apiUrl);
  }

  // Method to fetch a specific fee by ID
  getFeeById(id: number): Observable<Fee> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<Fee>(url);
  }

  // Method to create a new fee
  createFee(fee: Fee): Observable<Fee> {
    return this.http.post<Fee>(this.apiUrl, fee);
  }

  // Method to update an existing fee
  updateFee(fee: Fee): Observable<Fee> {
    const url = `${this.apiUrl}/${fee.feeId}`;
    return this.http.put<Fee>(url, fee);
  }

  // Method to delete a fee by ID
  deleteFee(id: number): Observable<any> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete(url);
  }
}
