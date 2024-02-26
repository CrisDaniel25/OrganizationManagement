import { Injectable, OnDestroy } from '@angular/core';
import { Select, Store } from '@ngxs/store';
import { Observable, Subject, Subscription } from 'rxjs';
import { SessionAction, SessionState } from 'src/app/shared/store';

@Injectable({
  providedIn: 'root'
})
export class AppService implements OnDestroy {
  @Select(SessionState.getUserRoles) userRoles$!: Observable<string[]>;

  userRoles!: string[];

  redirectUrl: string = '/';
  loading: boolean = false;

  notifierDynamicGrigToUpdateData: Subject<any> = new Subject();

  userRolesSubscription!: Subscription;

  constructor(private store: Store) {
    this.userRolesSubscription = this.userRoles$.subscribe((roles) => {
      this.userRoles = roles;
    })
  }

  checkMenuRoleAccess(menuRole: string[]) {
    return menuRole
      ? menuRole.some((r) => this.userRoles.indexOf(r) >= 0)
      : false;
  }

  logout() {
    this.store.dispatch(new SessionAction.Logout());
  }

  ngOnDestroy(): void {
    this.userRolesSubscription.unsubscribe();
  }
}
