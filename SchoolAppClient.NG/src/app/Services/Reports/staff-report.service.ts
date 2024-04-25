import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StaffReportService {

  options: any = {
    responseType: 'text'
  }
  constructor(private http: HttpClient) { }

  apiUrl: string = "https://localhost:7225/api/WebReports";

  public GetReport(): Observable<any> {
    return this.http.get<any>(this.apiUrl , this.options);
  }
}
