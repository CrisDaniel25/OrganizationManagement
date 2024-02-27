import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { MenuRoles } from 'src/app/core/constants/menu-roles.constant';
import { FieldConfig, GridColumns } from 'src/app/shared/interfaces';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent {
  @Input() clientId: string | number | null = null;
  title = 'employee.title';
  service = 'employees';
  entityView = 'employee';

  create: string[] = MenuRoles.EMPLOYEES_CREATE;
  edit: string[] = MenuRoles.EMPLOYEES_UPDATE;
  delete: string[] = MenuRoles.EMPLOYEES_DELETE
  log: string[] = MenuRoles.AUDITS;

  searchDdlFields: FieldConfig[] = [
    {
      label: 'user.status',
      name: 'IsActive',
      options: [
        { id: true, desc: 'employee.active', isOn: true },
        { id: false, desc: 'employee.inactive' },
      ],
    },
  ];

  displayedColumns: GridColumns[] = [
    { name: 'EmployeeId', label: 'employee.id', isId: true },
    { name: 'FirstName', label: 'employee.first-name' },
    { name: 'LastName', label: 'employee.last-name' },
    { name: 'Email', label: 'employee.email' },
    { name: 'Department', label: 'employee.department' },
    { name: 'Position', label: 'employee.position' },
    { name: 'StartDate', label: 'employee.start-date', isDate: true, isTime: true },
    { name: 'IsActive', label: 'employee.is-active', hasChip: true, searchFields: this.searchDdlFields },
  ];

  constructor(private router: Router) { }

  onLog(event: any) {
    this.router.navigate(['/home/audit-list'], {
      state: { tableName: 'Employees', keyValues: `{"EmployeeId":${event}}` },
    });
  }
}
