import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FeeType } from '../Models/FeeType';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FeeTypeService {

  private apiUrl = 'https://localhost:7225/api/FeeTypes';

  constructor(private http: HttpClient) { }

  // Retrieve all fee types
  getFeeTypes(): Observable<FeeType[]> {
    return this.http.get<FeeType[]>(this.apiUrl);
  }

  // Retrieve a specific fee type by ID
  getFeeTypeById(id: number): Observable<FeeType> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<FeeType>(url);
  }

  // Create a new fee type
  createFeeType(feeTypeData: FeeType): Observable<FeeType> {
    return this.http.post<FeeType>(this.apiUrl, feeTypeData);
  }




  // Update an existing fee type
  updateFeeType(feeType: FeeType): Observable<FeeType> {
    const url = `${this.apiUrl}/${feeType.feeTypeId}`;
    return this.http.put<FeeType>(url, feeType);
  }

  // Delete a fee type
  deleteFeeType(id: number): Observable<FeeType> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete<FeeType>(url);
  }
}
