import { Component, HostListener } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Store } from '@ngxs/store';
import { AppService } from 'src/app/core/services/app.service';
import { SessionAction } from 'src/app/shared/store';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  @HostListener('window:keydown.enter', ['$event'])
  handleKeyDown(event: KeyboardEvent) {
    this.onSubmit();
  }

  loginForm!: FormGroup;

  passwordFieldTypeDefinition: 'password' | 'text' = 'password';
  isPasswordVisibile: boolean = false;

  constructor(private store: Store, private appService: AppService) {
    this.setupForm();
  }

  setupForm() {
    this.loginForm = new FormGroup({
      userName: new FormControl(null, [
        Validators.required,
        Validators.minLength(3),
      ]
      ),
      password: new FormControl(null, [
        Validators.required,
        Validators.minLength(1),
      ]
      )
    })
  }

  onChangePasswordTextVisibility() {
    this.isPasswordVisibile = !this.isPasswordVisibile;

    if (this.isPasswordVisibile) this.passwordFieldTypeDefinition = 'text';
    else this.passwordFieldTypeDefinition = 'password';
  }

  onSubmit() {
    try {
      this.appService.loading = true
      this.store.dispatch(new SessionAction.Login(this.loginForm.value)).subscribe(() => { this.appService.loading = false });
    } catch (error: any) {
      this.appService.loading = false;
    }
  }
}
