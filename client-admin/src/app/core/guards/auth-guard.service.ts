import { Injectable } from '@angular/core';
import { ActivatedRoute, ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';
import { AppService } from '../services/app.service';
import { Session } from 'src/app/shared/interfaces';
import { map } from 'rxjs/operators';
import { Store } from '@ngxs/store';
import { SessionState } from 'src/app/shared/store';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService  {

  constructor(
    private store: Store,
    private appService: AppService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ) {
    const url: string = state.url;
    const expectedRoles = route.data['expectedRoles'];
    return this.checkLogin(url, expectedRoles, route);
  }

  canActivateChild(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ) {
    return this.canActivate(route, state);
  }

  checkLogin(url: string, expectedRoles: any, route: ActivatedRouteSnapshot) {
    return this.store.select(SessionState.getSession).pipe(map((session: Session) => {
      if (session) {
        if (session.UserPasswordHasBeenReset == true) {
          if (!url.includes('change-password'))
            this.router.navigate([`/user/${session.UserId}/change-password`]);
          return true;
        }

        if (
          expectedRoles == null ||
          expectedRoles.some((r: any) => session.Claims.indexOf(r) >= 0)
        ) {
          return true;
        }
      }

      this.appService.redirectUrl = url;
      this.router.navigate(['login']);

      return false
    }))
  }
}
