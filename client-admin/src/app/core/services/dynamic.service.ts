import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DynamicService {
  serviceName: string = '';

  constructor(private http: HttpClient) { }

  get(filter: string) {
    return this.http.get(
      `${environment.baseURL}/${this.serviceName}${!!filter && filter.length > 0 ? `/?${filter}` : ''}`
    );
  }

  getChildList(parentId: string | number, parentName: string) {
    return this.http.get(`${environment.baseURL}/${this.serviceName}/${parentName}/${parentId}`);
  }

  getById(id: string | number): Promise<any> {
    return <Promise<any>>(
      this.http
        .get(`${environment.baseURL}/${this.serviceName}/${id}`)
        .toPromise()
    );
  }

  post(payload: any): Promise<any> {
    return <Promise<any>>(
      this.http
        .post(`${environment.baseURL}/${this.serviceName}/`, payload)
        .toPromise()
    );
  }

  put(id: string | number, payload: any): Promise<any> {
    return <Promise<any>>(
      this.http
        .put(`${environment.baseURL}/${this.serviceName}/${id}`, payload)
        .toPromise()
    );
  }
}
