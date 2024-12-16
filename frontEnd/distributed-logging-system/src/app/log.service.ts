import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LogService {
  private apiUrl = 'https://localhost:7014/api/logs';
  constructor(private http: HttpClient) {}

  getLogs(data? : any): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/?start=${data?.startDate}&end=${data?.endDate}&level=${data?.level}`);
  }

  addLog(data? : any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}` , data)
  }

  
}
