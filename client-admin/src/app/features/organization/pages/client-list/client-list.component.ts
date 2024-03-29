import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MenuRoles } from 'src/app/core/constants/menu-roles.constant';
import { FieldConfig, GridColumns } from 'src/app/shared/interfaces';

@Component({
  selector: 'app-client-list',
  templateUrl: './client-list.component.html',
  styleUrls: ['./client-list.component.css']
})
export class ClientListComponent {
  title = 'client.title';
  service = 'clients';
  entityView = 'client';

  create: string[] = MenuRoles.CLIENTS_CREATE;
  edit: string[] = MenuRoles.CLIENTS_UPDATE;
  delete: string[] = MenuRoles.CLIENTS_UPDATE;
  log: string[] = MenuRoles.AUDITS;

  searchDdlFields: FieldConfig[] = [];

  displayedColumns: GridColumns[] = [
    { name: 'ClientId', label: 'client.id', isId: true },
    { name: 'Name', label: 'client.name' },
    { name: 'Email', label: 'client.email' },
    { name: 'CompanySize', label: 'client.company-size' },
    { name: 'Founded', label: 'client.founded', isDate: true, isTime: true },
  ];

  constructor(private router: Router) { }

  onLog(event: any) {
    this.router.navigate(['/home/audit-list'], {
      state: { tableName: 'Clients', keyValues: `{"ClientId":${event}}` },
    });
  }
}
