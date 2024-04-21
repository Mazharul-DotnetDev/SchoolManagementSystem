import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Examtype } from '../Models/examtype';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ExamtypeService {

  constructor(private http: HttpClient) { }
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',

    })
  }

  httpFormOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'multipart/form-data',

    })
  }


  apiUrl: string = "https://localhost:7225/api/ExamTypes";


  public GetdbsExamType(): Observable<Examtype[]> {

    return this.http.get<Examtype[]>(this.apiUrl);
  }
  public GetExamType(id: number): Observable<Examtype> {

    return this.http.get<Examtype>(this.apiUrl + '/' + id);
  }
  public SaveExamType(examType: Examtype): Observable<Examtype> {

    return this.http.post<Examtype>(this.apiUrl, JSON.stringify(examType), this.httpOptions);
  }
  public UpdateExamType(examType: Examtype): Observable<Examtype> {

    return this.http.put<Examtype>(this.apiUrl + '/' + examType.examTypeId, JSON.stringify(examType), this.httpOptions);
  }
  public DeleteExamType(id: number): Observable<Examtype> {

    return this.http.delete<Examtype>(this.apiUrl + '/' + id);
  }




}
