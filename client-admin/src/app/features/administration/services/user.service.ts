import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from 'src/app/core/models/user';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) { }

  getUsers(): Promise<User[]> {
    return <Promise<User[]>>(this.http.get(`${environment.baseURL}/users/`).toPromise());
  }

  getUser(id: string): Promise<User> {
    return <Promise<User>>(
      this.http.get(`${environment.baseURL}/users/${id}`).toPromise()
    );
  }

  create(payload: any): Promise<User> {
    return <Promise<User>>(this.http.post(`${environment.baseURL}/users/`, payload).toPromise());
  }

  update(id: string | number, payload: any): Promise<User> {
    return <Promise<User>>(this.http
      .put(`${environment.baseURL}/users/${id}`, payload)
      .toPromise());
  }

  getADUserInfo(userName: string): Observable<User> {
    return this.http.get<User>(`${environment.baseURL}/users/ad/${userName}`);
  }

  checkUserExist(userName: string) {
    const res: any = this.http.get(
      `${environment.baseURL}/users/checkUserName/${userName}`
    );

    return res;
  }

  changePassword(payload: any) {
    return this.http
      .patch(`${environment.baseURL}/users/ChangePassword`, payload);
  }
}
