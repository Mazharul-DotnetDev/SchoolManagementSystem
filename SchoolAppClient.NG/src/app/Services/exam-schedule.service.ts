import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ExamScheduleVm } from '../Models/exam-schedule-vm';
import { GetExamScheduleOptionsResponse } from '../Models/get-exam-schedule-options-response';
import { ExamSchedule } from '../Models/exam-schedule';

@Injectable({
  providedIn: 'root'
})
export class ExamScheduleService {

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

  apiUrl: string = "https://localhost:7225/api/ExamSchedules";

  public GetExamSchedules(): Observable<ExamScheduleVm[]> {
    return this.http.get<ExamScheduleVm[]>(this.apiUrl);
  }

  public GetExamScheduleOptions(): Observable<GetExamScheduleOptionsResponse[]> {
    return this.http.get<GetExamScheduleOptionsResponse[]>(this.apiUrl + '/GetExamScheduleOptions');
  }

  public GetExamScheduleById(id: number): Observable<ExamScheduleVm> {
    return this.http.get<ExamScheduleVm>(this.apiUrl + '/' + id);
  }

  public SaveExamSchedule(examSchedule: ExamSchedule): Observable<any> {
    return this.http.post<ExamSchedule>(this.apiUrl, examSchedule, this.httpOptions);
  }

  public UpdateExamSchedule(examSchedule: ExamSchedule): Observable<ExamSchedule> {
    return this.http.put<ExamSchedule>(this.apiUrl + '/' + examSchedule.examScheduleId, examSchedule, this.httpOptions);
  }
  public DeleteExamSchedule(id: number): Observable<ExamSchedule> {
    return this.http.delete<ExamSchedule>(this.apiUrl + '/' + id);
  }



}
