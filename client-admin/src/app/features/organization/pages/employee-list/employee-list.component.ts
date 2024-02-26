import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MenuRoles } from 'src/app/core/constants/menu-roles.constant';
import { FieldConfig, GridColumns } from 'src/app/shared/interfaces';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent {
  title = 'employee.title';
  service = 'employees';
  entityView = 'employee';

  create: string[] = MenuRoles.EMPLOYEES_CREATE;
  edit: string[] = MenuRoles.EMPLOYEES_UPDATE;
  delete: string[] = MenuRoles.EMPLOYEES_DELETE
  log: string[] = MenuRoles.AUDITS;

  searchDdlFields: FieldConfig[] = [
  ];

  displayedColumns: GridColumns[] = [
  ];

  constructor(private router: Router) { }

  onLog(event: any) {
    this.router.navigate(['/home/audit-list'], {
      state: { tableName: 'Employees', keyValues: `{"EmployeeId":${event}}` },
    });
  }
}
