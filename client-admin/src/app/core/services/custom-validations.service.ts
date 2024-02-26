import { Injectable, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { AbstractControl, FormGroup, ValidatorFn } from '@angular/forms';
import { Select } from '@ngxs/store';
import { SessionState } from 'src/app/shared/store';
import { Observable, Subscription } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomValidationsService implements OnDestroy {
  @Select(SessionState.getUserId) userId$!: Observable<number>;

  userIdSubscription!: Subscription;

  constructor(private route: Router) { }

  patternValidator(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } => {
      if (!control.value) {
        return {
          validPassword: true
        };
      }
      const regex = new RegExp('^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$');
      const valid = regex.test(control.value);
      return valid ? { validPassword: true } : { invalidPassword: true };
    };
  }

  matchPassword(password: string, confirmPassword: string) {
    return (formGroup: FormGroup) => {
      const passwordControl = formGroup.controls[password];
      const confirmPasswordControl = formGroup.controls[confirmPassword];

      if (!passwordControl || !confirmPasswordControl) {
        return null;
      }

      if (
        confirmPasswordControl.errors &&
        !confirmPasswordControl.errors['passwordMismatch']
      ) {
        return null;
      }

      if (passwordControl.value !== confirmPasswordControl.value) {
        confirmPasswordControl.setErrors({ passwordMismatch: true });
      } else {
        confirmPasswordControl.setErrors(null);
      }

      return null;
    };
  }

  userNameValidator(userControl: AbstractControl) {
    return new Promise((resolve) => {
      setTimeout(() => {
        if (this.validateUserName(userControl.value)) {
          resolve({ userNameNotAvailable: true });
        } else {
          resolve(null);
        }
      }, 1000);
    });
  }

  validateUserName(userName: string) {
    const UserList = ['ankit', 'admin', 'user', 'superuser'];
    return UserList.indexOf(userName) > -1;
  }

  changePassword() {
    this.userIdSubscription = this.userId$.subscribe((userId) => {
      this.route.navigate([
        `/user/${userId}/change-password`,
      ]);

      return userId;
    })
  }

  ngOnDestroy(): void {
    this.userIdSubscription.unsubscribe();
  }
}
