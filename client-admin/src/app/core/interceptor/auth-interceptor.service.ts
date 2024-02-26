import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppService } from '../services/app.service';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { SessionState } from 'src/app/shared/store';
import { Select } from '@ngxs/store';

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptorService implements HttpInterceptor {
  @Select(SessionState.getToken) token$!: Observable<string>;
  token!: string;

  constructor(private appService: AppService) {
    this.token$.subscribe(token => this.token = token);
  }

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    let headers = {
      Authorization: `Bearer ${this.token}`,
    };

    request = request.clone({
      setHeaders: headers,
    });

    return next.handle(request).pipe(
      tap(
        () => { },
        (err: any) => {
          if (err instanceof HttpErrorResponse) {
            if (err.status !== 401) {
              return;
            }
            this.appService.logout();
          }
        }
      )
    );
  }

}
