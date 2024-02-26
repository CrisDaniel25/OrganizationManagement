import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormAccess } from 'src/app/core/models/formAccessType';
import { Role } from 'src/app/core/models/role';
import { User } from 'src/app/core/models/user';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RoleService {
  constructor(private http: HttpClient) { }

  get(): Promise<Role[]> {
    return <Promise<Role[]>>(
      this.http.get(`${environment.baseURL}/roles/`).toPromise()
    );
  }

  getById(id: string): Promise<Role> {
    return <Promise<Role>>(
      this.http.get(`${environment.baseURL}/roles/${id}`).toPromise()
    );
  }

  update(id: string, payload: Role): Promise<Role> {
    return <Promise<Role>>(
      this.http.put(`${environment.baseURL}/roles/${id}`, payload).toPromise()
    );
  }

  create(payload: Role): Promise<Role> {
    return <Promise<Role>>(
      this.http.post(`${environment.baseURL}/roles/`, payload).toPromise()
    );
  }

  permissions(id: string | null): Promise<FormAccess[]> {
    return <Promise<FormAccess[]>>(
      this.http
        .get(`${environment.baseURL}/roles/${id}/permissions`)
        .toPromise()
    );
  }

  users(id?: string): Promise<User[]> {
    return <Promise<User[]>>(
      this.http.get(`${environment.baseURL}/roles/${id}/users`).toPromise()
    );
  }

  checkName(name: string) {
    const res: any = this.http.get(
      `${environment.baseURL}/roles/checkName/${name}`
    );
    return res;
  }

}
