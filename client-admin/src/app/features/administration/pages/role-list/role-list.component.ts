import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MenuRoles } from 'src/app/core/constants/menu-roles.constant';
import { FieldType } from 'src/app/core/enums/field-type.enum';
import { InputType } from 'src/app/core/enums/input-type.enum';
import { FieldConfig, GridColumns } from 'src/app/shared/interfaces';

@Component({
  selector: 'app-role-list',
  templateUrl: './role-list.component.html',
  styleUrls: ['./role-list.component.css']
})
export class RoleListComponent {
  title = 'role.title';
  service = 'roles';
  entityView = 'role';

  create: string[] = MenuRoles.ROLES_CREATE;
  edit: string[] = MenuRoles.ROLES_UPDATE;
  log: string[] = MenuRoles.AUDITS;

  searchDdlFields: FieldConfig[] = [
    {
      label: 'role.status',
      name: 'GroupStatus',
      options: [
        { id: '', desc: 'role.all' },
        { id: 'A', desc: 'role.active', isOn: true },
        { id: 'I', desc: 'role.inactive' },
      ],
    },
  ];

  displayedColumns: GridColumns[] = [
    { name: 'GroupId', label: 'role.id', isId: true },
    { name: 'GroupName', label: 'role.name' },
    { name: 'GroupDescription', label: 'role.description' },
    {
      name: 'GroupStatus',
      label: 'role.status',
      hasChip: true,
      searchFields: this.searchDdlFields,
    },
  ];

  constructor(private router: Router) { }

  onLog(event: any) {
    this.router.navigate(['/home/audit-list'], {
      state: { tableName: 'Groups', keyValues: `{"GroupId":${event}}` },
    });
  }
}
