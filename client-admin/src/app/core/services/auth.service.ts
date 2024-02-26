
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { loginForm } from 'src/app/shared/interfaces';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  login(payload: loginForm) {
    return this.http.post(`${environment.baseURL}/Authentication/Login`, payload)
  }
}