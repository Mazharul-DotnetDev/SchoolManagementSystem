import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Mark } from '../Models/marks';

/*const baseUrl = 'http://localhost:5000/api/Marks';*/ 

@Injectable({
  providedIn: 'root'
})

export class MarksService {

  private apiUrl = 'https://localhost:7225/api/Marks';

  constructor(private http: HttpClient) { }

  getAllMarks(): Observable<Mark[]> {
    return this.http.get<Mark[]>(this.apiUrl);
  }

  getMarkById(id: number): Observable<Mark> {
    return this.http.get<Mark>(`${this.apiUrl}/${id}`);
  }

  //addMark(mark: Mark): Observable<any> {
  //  return this.http.post<any>(this.apiUrl, mark);
  //}

  addMark(mark: Mark): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}`, mark);
  }


  updateMark(id: number, mark: Mark): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/${id}`, mark);
  }

  deleteMark(id: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/${id}`);
  }
}
