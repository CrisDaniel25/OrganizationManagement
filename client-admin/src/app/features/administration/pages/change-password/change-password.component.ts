import { Component, HostListener, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomValidationsService } from 'src/app/core/services/custom-validations.service';
import { AppService } from 'src/app/core/services/app.service';
import { Store } from '@ngxs/store';
import { SessionAction, SessionState } from 'src/app/shared/store';
import { map } from 'rxjs';
import { MessengerService } from 'src/app/core/services/messenger.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {
  @HostListener('window:keydown.enter', ['$event'])
  handleKeyDown(event: KeyboardEvent) {
    this.onSubmit();
  }
  
  id: string = '';
  loading = false;
  reactiveForm!: FormGroup;

  passwordFieldTypeDefinitionOne: 'password' | 'text' = 'password';
  isPasswordVisibileOne: boolean = false;

  passwordFieldTypeDefinitionTwo: 'password' | 'text' = 'password';
  isPasswordVisibileTwo: boolean = false;

  regex: string = '^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$';

  constructor(
    private store: Store,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private customValidator: CustomValidationsService,
    private router: Router,
    private appService: AppService
  ) {
    this.setUpForm();
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id') || '';
    this.store.select(SessionState.getSession).pipe(map(session => {
      if (session.TypeAutentication == 'EX') {
        this.setUpForm();
      } else {
        this.onBack();
      }
    }));
  }

  onChangePasswordTextVisibilityOne() {
    this.isPasswordVisibileOne = !this.isPasswordVisibileOne;

    if (this.isPasswordVisibileOne) this.passwordFieldTypeDefinitionOne = 'text';
    else this.passwordFieldTypeDefinitionOne = 'password';
  }

  onChangePasswordTextVisibilityTwo() {
    this.isPasswordVisibileTwo = !this.isPasswordVisibileTwo;

    if (this.isPasswordVisibileTwo) this.passwordFieldTypeDefinitionTwo = 'text';
    else this.passwordFieldTypeDefinitionTwo = 'password';
  }

  async onSubmit() {
    try {
      if (this.id && this.reactiveForm.valid) {
        this.appService.loading = true;
        this.store.dispatch(new SessionAction.ChangePassword(this.reactiveForm.value)).subscribe(() => {
          this.appService.redirectUrl = '';
          this.appService.loading = false;
        });
      }
    } catch (error: any) {
      this.loading = false;
    }
  }

  onBack() {
    this.router.navigate(['/login']);
  }

  setUpForm() {
    this.reactiveForm = this.fb.group(
      {
        Password: ['', Validators.required],
        NewPassword: [
          '',
          Validators.compose([
            Validators.required,
            Validators.pattern(this.regex),
          ]),
        ],
        ConfirmNewPassword: ['', [Validators.required]],
      },
      {
        validator: this.customValidator.matchPassword(
          'newPassword',
          'confirmNewPassword'
        ),
      }
    );
  }
}
