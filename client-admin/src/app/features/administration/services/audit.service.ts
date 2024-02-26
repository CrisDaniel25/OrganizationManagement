import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuditService {

  constructor(private http: HttpClient) {}

  getById(id: string): Promise<any> {
    return <Promise<any[]>>(
      this.http.get(`${environment.baseURL}/audits/${id}`).toPromise()
    );
  }

  getTables(): Promise<any[]> {
    return <Promise<any[]>>(
      this.http.get(`${environment.baseURL}/audits/getTables`).toPromise()
    );
  }
}
