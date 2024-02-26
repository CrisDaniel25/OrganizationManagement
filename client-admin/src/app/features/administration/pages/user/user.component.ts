
import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import {
  MatAutocompleteSelectedEvent,
  MatAutocomplete,
} from '@angular/material/autocomplete';
import { MatChipList } from '@angular/material/chips';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { UserType } from 'src/app/core/constants/user-type.constant';
import { UserService } from '../../services/user.service';
import { AppService } from 'src/app/core/services/app.service';
import { MenuRoles } from 'src/app/core/constants/menu-roles.constant';
import { Role } from 'src/app/core/models/role';
import { RoleService } from '../../services/role.service';
import { MessengerService } from 'src/app/core/services/messenger.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css'],
})
export class UserComponent implements OnInit {
  id!: string | null;
  checkNo!: string;
  reactiveForm!: FormGroup;

  loginProvider: any[] = [
    { id: UserType.EX, desc: 'user.local' },
    { id: UserType.AD, desc: 'user.AD' },
  ];

  userStatus: any[] = [
    { id: 'A', desc: 'user.active' },
    { id: 'I', desc: 'user.inactive' },
    { id: 'L', desc: 'user.lock' },
  ];

  editAccess = false;
  createAccess = false;
  readOnlyAccess = true;

  visible = true;
  selectable = true;
  removable = true;

  separatorKeysCodes: number[] = [ENTER, COMMA];

  filteredRoles!: Observable<any[]>;
  filteredStatus!: Observable<string[]>;

  roles: Role[] = [];
  status: any[] = [];
  allRoles: any[] = [];
  allStatus: any[] = [];

  userNameTaken: boolean = false;
  userADExist: boolean = false;
  currentUserName: string = '';

  regex: string = '^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$';

  @ViewChild('roleInput') roleInput!: ElementRef<HTMLInputElement>;
  @ViewChild('officeInput') officeInput!: ElementRef<HTMLInputElement>;
  @ViewChild('matAutocompleteRole') matAutocompleteRole!: MatAutocomplete;
  @ViewChild('matAutocompleteOffice') matAutocompleteOffice!: MatAutocomplete;
  @ViewChild('chipListRoles') chipListRoles!: MatChipList;
  @ViewChild('chipListOffices') chipListOffices!: MatChipList;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService,
    private roleService: RoleService,
    private appService: AppService,
    private messengerService: MessengerService
  ) {
    this.setupForm(null);
  }

  async ngOnInit() {
    try {
      this.appService.loading = true;

      this.id = this.route.snapshot.paramMap.get('id');

      if (this.id) {
        const res = await this.userService.getUser(this.id);
        if (res) {
          await this.setupForm(res);
        }
      }
      this.loadRoles();
      this.appService.loading = false;
    } catch (error: any) {
      this.appService.loading = false;

      this.messengerService.addMessage(error)
    }
  }

  async onSubmit() {
    try {
      if (
        this.id &&
        this.editAccess &&
        this.reactiveForm.valid &&
        !this.userNameTaken &&
        this.userADExist
      ) {
        this.appService.loading = true;

        await this.userService.update(
          this.id,
          this.reactiveForm.value
        );
        this.appService.loading = false;
        this.onBack();
      } else if (
        !this.id &&
        this.createAccess &&
        this.reactiveForm.valid &&
        !this.userNameTaken &&
        this.userADExist
      ) {
        this.appService.loading = true;

        await this.userService.create(
          this.reactiveForm.value
        );
        this.appService.loading = false;
        this.onBack();
      }
    } catch (error: any) {
      this.appService.loading = false;

      this.messengerService.addMessage(error)
    }
  }

  onBack() {
    this.router.navigate(['/home/user-list']);
  }

  async setupForm(object: any) {
    this.editAccess = this.appService.checkMenuRoleAccess(
      MenuRoles.USERS_UPDATE
    );
    this.createAccess = this.appService.checkMenuRoleAccess(
      MenuRoles.USERS_CREATE
    );
    this.readOnlyAccess = !this.editAccess && !this.editAccess;

    if (object) {
      this.roles = object.GroupUsers.map((e: any) => {
        return e.Group;
      });

      this.currentUserName = object.UserLogin;

      this.reactiveForm = new FormGroup({
        UserLogin: new FormControl(
          { value: object.UserLogin, disabled: false },
          [Validators.required]
        ),

        UserName: new FormControl({ value: object.UserName, disabled: false }, [
          Validators.required,
        ]),

        TypeAutentication: new FormControl(object.TypeAutentication, [
          Validators.required,
        ]),

        UserStatus: new FormControl(object.UserStatus, [Validators.required]),

        GroupsAlt: new FormControl(
          this.roles.map((r) => {
            return r.GroupId;
          })
        ),

        Password: new FormControl({ value: object.Password, disabled: true }),

        UserPhone: new FormControl(object.UserPhone),

        UserEmail: new FormControl(object.UserEmail, [
          Validators.required,
          Validators.email,
        ]),
      });
    } else {
      this.reactiveForm = new FormGroup({
        UserLogin: new FormControl({ value: '', disabled: false }, [
          Validators.required,
        ]),

        UserName: new FormControl({ value: null, disabled: false }, [
          Validators.required,
        ]),

        TypeAutentication: new FormControl(UserType.EX, [Validators.required]),

        UserStatus: new FormControl(null, [Validators.required]),

        GroupsAlt: new FormControl([]),

        Password: new FormControl({ value: null, disabled: true }),

        UserPhone: new FormControl(''),

        UserEmail: new FormControl('', [Validators.required, Validators.email]),
      });
    }

    if (this.readOnlyAccess) {
      this.reactiveForm.disable();

      this.roleInput ? (this.roleInput.nativeElement.disabled = true) : null;
      this.officeInput
        ? (this.officeInput.nativeElement.disabled = true)
        : null;

      this.chipListRoles ? (this.chipListRoles.disabled = true) : null;
      this.chipListOffices ? (this.chipListOffices.disabled = true) : null;
    } else if (!this.readOnlyAccess) {
      this.passwordValidation(
        this.reactiveForm.controls
          ? this.reactiveForm.controls['TypeAutentication'].value
          : ''
      );

      const userLogin: string | undefined | null = this.reactiveForm.controls['UserLogin'].value;
      if (userLogin && userLogin.length > 0) this.userNameValidation(this.reactiveForm.controls['UserLogin'].value);

      this.reactiveForm.controls['TypeAutentication'].valueChanges.subscribe(
        (x) => {
          this.userNameValidation(this.reactiveForm.controls['UserLogin'].value);
          this.passwordValidation(x);
        }
      );

      this.reactiveForm.controls['UserLogin'].valueChanges.subscribe(
        (userName: string) => {
          this.reactiveForm.controls['UserName'].setValue('');
          this.reactiveForm.controls['UserEmail'].setValue('');
          this.reactiveForm.controls['UserPhone'].setValue('');

          if (userName)
            this.userNameValidation(userName);
        }
      );
    }
  }

  private passwordValidation(userType: string) {
    if (userType === UserType.EX && this.id) {
      this.reactiveForm.controls['Password'].enable();
      this.reactiveForm.controls['Password'].setValidators([
        Validators.pattern(this.regex)

      ]);
    } else if (userType === UserType.EX && !this.id) {
      this.reactiveForm.controls['Password'].enable();
      this.reactiveForm.controls['Password'].setValidators([
        Validators.required,
        Validators.pattern(this.regex)
      ]);
    } else {
      this.reactiveForm.controls['Password'].disable();
      this.reactiveForm.controls['Password'].clearValidators();
    }
  }

  private userNameValidation(userName: string) {
    this.userService.checkUserExist(userName).subscribe(async (res: any) => {
      this.appService.loading = false;
      this.userNameTaken =
        userName.toLowerCase() == this.currentUserName.toLowerCase() &&
          this.currentUserName
          ? false
          : !res;
      //check AD
      if (
        this.reactiveForm.controls['TypeAutentication'].value == UserType.AD &&
        userName.length > 3
      ) {
        this.userService.getADUserInfo(userName).subscribe(
          (user) => {
            this.reactiveForm.controls['UserName'].setValue(user.UserName);
            this.reactiveForm.controls['UserEmail'].setValue(user.UserEmail);
            this.reactiveForm.controls['UserPhone'].setValue(user.UserPhone);
            this.userADExist = true;
          },
          (error: any) => {
            this.reactiveForm.controls['UserName'].setValue('');
            this.reactiveForm.controls['UserEmail'].setValue('');
            this.reactiveForm.controls['UserPhone'].setValue('');
            this.userADExist = false;
          }
        );
      } else {
        if (this.reactiveForm.controls['TypeAutentication'].value == UserType.EX) {
          this.userADExist = true;
        }
      }
    });
  }

  private async loadRoles() {
    try {
      this.allRoles = [];
      const res: Role[] = await this.roleService.get();
      this.allRoles = res
        .filter((x) => !this.roles.some((y) => y.GroupId == x.GroupId))
        .map((role) => {
          return role;
        });

      this.filteredRoles = this.reactiveForm.controls['GroupsAlt'].valueChanges.pipe(
        startWith(null),
        map((role: any | null) =>
          role ? this._filterRoles(role) : this.allRoles.slice()
        )
      );
    } catch (error: any) {
      this.messengerService.addMessage(error)
    }
  }

  onRemoveRole(role: any): void {
    const index = this.roles.indexOf(role);

    if (index >= 0) {
      this.roles.splice(index, 1);
    }

    this.reactiveForm.controls['GroupsAlt'].setValue(
      this.roles.map((r) => {
        return r.GroupId;
      })
    );

    this.loadRoles();
  }

  onSelectedRole(event: MatAutocompleteSelectedEvent): void {
    this.roles.push(event.option.value);
    this.roleInput.nativeElement.value = '';

    this.reactiveForm.controls['GroupsAlt'].setValue(
      this.roles.map((r) => {
        return r.GroupId;
      })
    );

    this.loadRoles();
  }

  private _filterRoles(value: string): any[] {
    if (typeof value === 'string') {
      const filterValue = value ? value.toLowerCase() : '';
      return this.allRoles
        ? this.allRoles.filter((role) =>
          role.groupName.toLowerCase().includes(filterValue)
        )
        : [];
    }

    return [];
  }
}
