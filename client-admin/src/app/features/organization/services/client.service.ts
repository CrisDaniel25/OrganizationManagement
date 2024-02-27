import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  constructor(private http: HttpClient) { }

  delete(id: string | number) {
    return this.http.delete(`${environment.baseURL}/clients/${id}`)
  }
}
