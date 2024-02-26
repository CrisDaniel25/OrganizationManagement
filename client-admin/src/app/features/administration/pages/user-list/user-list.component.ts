import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MenuRoles } from 'src/app/core/constants/menu-roles.constant';
import { FieldConfig, GridColumns } from 'src/app/shared/interfaces';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent {
  title = 'user.title';
  service = 'users';
  entityView = 'user';

  create: string[] = MenuRoles.USERS_CREATE;
  edit: string[] = MenuRoles.USERS_UPDATE;
  log: string[] = MenuRoles.AUDITS;

  searchDdlFields: FieldConfig[] = [
    {
      label: 'user.status',
      name: 'UserStatus',
      options: [
        { id: '', desc: 'user.all' },
        { id: 'A', desc: 'user.active', isOn: true },
        { id: 'I', desc: 'user.inactive' },
        { id: 'L', desc: 'user.lock' },
      ],
    },
  ];

  displayedColumns: GridColumns[] = [
    { name: 'UserId', label: 'user.id', isId: true },
    { name: 'UserLogin', label: 'user.username' },
    { name: 'FullName', label: 'user.fullname' },
    {
      name: 'UserStatus',
      label: 'user.status',
      hasChip: true,
      searchFields: this.searchDdlFields,
    },
  ];

  constructor(private router: Router) { }

  onLog(event: any) {
    this.router.navigate(['/home/audit-list'], {
      state: { tableName: 'Users', keyValues: `{"UserId":${event}}` },
    });
  }
}
