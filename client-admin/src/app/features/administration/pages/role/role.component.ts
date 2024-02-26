import {
  animate,
  state,
  style,
  transition,
  trigger,
} from '@angular/animations';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ThemePalette } from '@angular/material/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { AccessType, FormAccess } from 'src/app/core/models/formAccessType';
import { Role } from 'src/app/core/models/role';
import { User } from 'src/app/core/models/user';
import { Observable } from 'rxjs'
import { startWith, map } from 'rxjs/operators'
import { AppService } from 'src/app/core/services/app.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MenuRoles } from 'src/app/core/constants/menu-roles.constant';
import { RoleService } from '../../services/role.service';
import { UserService } from '../../services/user.service';
import { HttpResponseEnum } from 'src/app/core/enums/http-response.enum';
import { MessengerService } from 'src/app/core/services/messenger.service';

@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.css'],
  animations: [
    trigger('detailExpand', [
      state(
        'collapsed',
        style({ height: '0px', minHeight: '0', visibility: 'hidden' })
      ),
      state('expanded', style({ height: '*', visibility: 'visible' })),
      transition(
        'expanded <=> collapsed',
        animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')
      ),
    ]),
  ],
})
export class RoleComponent implements OnInit {
  @ViewChild('permissionsTable', { read: MatSort, static: true })
  sortPermissions!: MatSort;
  @ViewChild('paginatorPermissions')
  paginatorPermissions!: MatPaginator;
  @ViewChild('usersTable', { read: MatSort, static: true })
  sortUsers!: MatSort;
  @ViewChild('paginatorUsers')
  paginatorUsers!: MatPaginator;
  @ViewChild('newUserInput') newUserInput!: ElementRef<HTMLInputElement>;

  dsPermissions: any;
  pageEventPermissions!: PageEvent;
  dcPermnissions: string[] = ['form'];
  expandedElement: any;
  isExpansionDetailRow = (i: number, row: Object) => row.hasOwnProperty('id');

  dsUsers: any;
  pageEventUsers!: PageEvent;
  dcUsers: string[] = ['userLogin', 'fullName', 'action'];

  pageSize = 10;
  pageSizeOptions: number[] = [5, 10, 25, 100];

  id!: string | null;
  reactiveForm!: FormGroup;
  accessTypes: FormAccess[] = [];

  status: any[] = [
    { id: 'A', desc: 'user.active' },
    { id: 'I', desc: 'user.inactive' },
  ];

  editAccess = false;
  createAccess = false;
  readOnlyAccess = true;

  nameTaken: boolean = false;
  currentName: string = '';

  rolesToCopy: Role[] = [];

  primaryColor: ThemePalette = 'primary';

  roleUsers: User[] = [];
  allUsers: any;

  stateCtrl = new FormControl();
  filteredUsers!: Observable<any[]>;

  constructor(
    private roleService: RoleService,
    private userService: UserService,
    private route: ActivatedRoute,
    private router: Router,
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
        const res: any = await this.roleService.getById(this.id);
        if (res) {
          await this.setupForm(res);
        }
      }
      this.appService.loading = false;
    } catch (error: any) {
      this.appService.loading = false;

      this.messengerService.addMessage(error)
    }
  }

  async setupForm(object: any) {
    this.editAccess = this.appService.checkMenuRoleAccess(
      MenuRoles.USERS_UPDATE
    );
    this.createAccess = this.appService.checkMenuRoleAccess(
      MenuRoles.USERS_CREATE
    );
    this.readOnlyAccess = !this.editAccess && !this.editAccess;

    this.fetchCopyRoles();

    if (object) {
      this.reactiveForm = new FormGroup({
        GroupName: new FormControl(
          { value: object.GroupName, disabled: false },
          [Validators.required, Validators.maxLength(50)]
        ),

        UsersAlt: new FormControl([]),

        GroupDescription: new FormControl(object.GroupDescription, [
          Validators.required,
          Validators.maxLength(500),
        ]),

        GroupStatus: new FormControl(object.GroupStatus, [Validators.required]),

        AccessTypes: new FormControl([], []),
      });

      await this.fetchPermissions(object.GroupId);
      await this.fetchRoleUsers(object.GroupId);
    } else {
      this.reactiveForm = new FormGroup({
        GroupName: new FormControl({ value: null, disabled: false }, [
          Validators.required,
        ]),

        UsersAlt: new FormControl([], []),

        GroupDescription: new FormControl(null, [Validators.required]),

        GroupStatus: new FormControl(null, [Validators.required]),

        AccessTypes: new FormControl(this.accessTypes, []),
      });
      await this.fetchPermissions(null);
      await this.fetchRoleUsers(null);
    }
    if (this.readOnlyAccess) {
      this.reactiveForm.disable();
    } else {
      this.onPermissionChange();
      this.currentName = object ? object.groupName : '';

      await this.fetchUsers();
      this.onSelectedUser(null);

      this.reactiveForm.controls['GroupName'].valueChanges.subscribe((e) => {
        if (e) {
          this.roleService.checkName(e).subscribe(
            (res: any) => {
              this.appService.loading = false;
              this.nameTaken =
                e.toLowerCase() == this.currentName.toLowerCase() &&
                  this.currentName
                  ? false
                  : !res;
            },
            (error: any) => {
              this.appService.loading = false;
              this.messengerService.addMessage(error)
            }
          );
        }
      });

      this.filteredUsers = this.stateCtrl.valueChanges.pipe(
        startWith(''),
        map((user) => (user ? this._filterUsers(user) : this.allUsers.slice()))
      );
    }
  }

  async onSubmit() {
    try {
      if (
        this.id &&
        this.editAccess &&
        this.reactiveForm.valid &&
        !this.nameTaken
      ) {
        this.appService.loading = true;
        const res = await this.roleService.update(
          this.id,
          this.reactiveForm.value
        );
        this.appService.loading = false;
        this.onBack();
      } else if (
        !this.id &&
        this.createAccess &&
        this.reactiveForm.valid &&
        !this.nameTaken
      ) {
        this.appService.loading = true;
        const res = await this.roleService.create(this.reactiveForm.value);
        this.appService.loading = false;
        this.onBack();
      }
    } catch (error: any) {
      this.appService.loading = false;
      this.messengerService.addMessage(error)
    }
  }

  onBack() {
    this.router.navigate(['/home/role-list']);
  }

  onPermissionChange() {
    if (this.accessTypes.length > 0) {
      this.reactiveForm.controls['AccessTypes'].setValue(
        this.accessTypes.map((r) => {
          return r;
        })
      );
    }
  }

  async onCopyPermissionChange(e: any) {
    try {
      this.appService.loading = true;
      await this.fetchPermissions(e.value);
      this.onPermissionChange();
    } catch (error) {
      this.appService.loading = false;
    } finally {
      this.appService.loading = false;
    }
  }

  onSelectAllChange(e: any) {
    this.accessTypes.forEach((x) => {
      if (!!x && x.AccessTypes) {
        x.AccessTypes.forEach((y) => {
          y.Checked = e.Checked;
          this.onPermissionChange();
        });
      }
    });
  }

  doFilter(value: any) {
    this.dsPermissions.filter = value.toString().trim().toLocaleLowerCase();
  }

  onSelectedUser(event: any) {
    if (
      event &&
      !this.roleUsers.some((p) => p.UserId === event.option.value.userId)
    ) {
      this.roleUsers.push(event.option.value);
      this.fetchRoleUsers(null);
    }
    this.newUserInput.nativeElement.value = '';
    this.reactiveForm.controls['UsersAlt'].setValue(
      this.roleUsers.map((r) => {
        return r.UserId;
      })
    );
  }

  async onDeleteUser(element: any) {
    const index = this.roleUsers.indexOf(element, 0);
    if (index > -1) {
      this.roleUsers.splice(index, 1);
      await this.fetchRoleUsers(null);
    }
  }

  async fetchPermissions(roleId: string | null) {
    try {
      this.accessTypes = await this.roleService.permissions(roleId);
      this.dsPermissions = new MatTableDataSource();
      this.dsPermissions.data = this.accessTypes;
      this.dsPermissions.paginator = this.paginatorPermissions;
      this.dsPermissions.sort = this.sortPermissions;
    } catch (error) {
      this.accessTypes = [];
    }
  }

  async fetchRoleUsers(roleId: string | null) {
    try {
      if (roleId) this.roleUsers = await this.roleService.users(roleId);
      if (!this.roleUsers) this.roleUsers = [];
      this.dsUsers = new MatTableDataSource();
      this.dsUsers.data = this.roleUsers;
      this.dsUsers.paginator = this.paginatorUsers;
      this.dsUsers.sort = this.sortUsers;
      this.reactiveForm.controls['UsersAlt'].setValue(
        this.roleUsers.map((r) => {
          return r.UserId;
        })
      );
    } catch (error) { }
  }

  async fetchCopyRoles() {
    try {
      this.rolesToCopy = await this.roleService.get();
    } catch (error) { }
  }

  async fetchUsers() {
    try {
      this.allUsers = await this.userService.getUsers();
    } catch (error) { }
  }

  star(accessTypes: AccessType[]) {
    return accessTypes.filter((x) => x.Checked).length === accessTypes.length;
  }

  starHalf(accessTypes: AccessType[]) {
    var checked = accessTypes.filter((x) => x.Checked);
    return checked.length < accessTypes.length && checked.length > 0;
  }

  private _filterUsers(value: string): any[] {
    if (typeof value === 'string') {
      const filterValue = value ? value.toLowerCase() : '';
      return this.allUsers
        ? this.allUsers.filter(
          (user: any) =>
            user.FullName.toLowerCase().includes(filterValue) ||
            user.UserLogin.toLowerCase().includes(filterValue)
        )
        : [];
    }
    return [];
  }
}
