import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ExamScheduleStandardVm } from '../Models/exam-schedule-standard-vm';
import { Observable } from 'rxjs';
import { CreateExamScheduleStandardVM } from '../Models/create-exam-schedule-standard-vm';
import { UpdateExamScheduleStandardVM } from '../Models/update-exam-schedule-standard-vm';

@Injectable({
  providedIn: 'root'
})
export class ExamScheduleStandardService {

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
  apiUrl: string = "https://localhost:7225/api/ExamScheduleStandards";


  public GetExamScheduleStandards(): Observable<ExamScheduleStandardVm[]> {
    return this.http.get<ExamScheduleStandardVm[]>(this.apiUrl);
  }
  public GetExamScheduleStandardsByID(id: number): Observable<ExamScheduleStandardVm> {

    return this.http.get<ExamScheduleStandardVm>(this.apiUrl + '/' + id);
  }
  public SaveExamScheduleStandards(examScheduleStandard: CreateExamScheduleStandardVM): Observable<any> {

    return this.http.post(this.apiUrl, examScheduleStandard, this.httpOptions);
  }


  updateExamScheduleStandards(examScheduleStandard: UpdateExamScheduleStandardVM): Observable<any> {
    return this.http.put<any>(this.apiUrl + '/' + examScheduleStandard.examScheduleStandardId, examScheduleStandard, this.httpOptions);
  }

  public DeleteExamScheduleStandard(id: number): Observable<any> {
    return this.http.delete(this.apiUrl + '/' + id);
  }




}
