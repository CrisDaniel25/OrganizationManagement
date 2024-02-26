import { Component, OnInit } from '@angular/core';
import { AuditComponent } from '../audit/audit.component';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { FieldConfig, GridColumns } from 'src/app/shared/interfaces';
import { AuditService } from '../../services/audit.service';

@Component({
  selector: 'app-audit-list',
  templateUrl: './audit-list.component.html',
  styleUrls: ['./audit-list.component.css']
})
export class AuditListComponent implements OnInit {
  title = 'audit.title'
  service = 'audits';
  entityView = '';
  serviceFilter = 'filter='; /* STATUS BORRADOR ID & CAMBIO ID & CANCELACION */

  edit: string[] = [];
  create: string[] = [];
  searchDdlFields: FieldConfig[] = [
    {
      label: 'audit.date',
      name: 'Date',
      isDate: true,
    },
  ];

  displayedColumns: GridColumns[] = [
    { name: 'Id', label: 'audit.id', isId: true },
    {
      name: 'KeyValues',
      label: 'audit.key',
    },
    {
      name: 'TableName',
      label: 'audit.entity',
    },
    {
      name: 'Operation',
      label: 'audit.operation'
    },
    {
      name: 'ChangeBy',
      label: 'audit.changeBy'
    },
    {
      name: 'Date',
      label: 'audit.date',
      isDate: true,
      searchFields: this.searchDdlFields,
    },
    {
      name: 'DateTime',
      label: 'audit.time',
      isTime: true,
    }
  ];

  constructor(
    private api: AuditService,
    public dialog: MatDialog,
    router: Router
  ) {
    if (router.getCurrentNavigation()) {
      let keyValues, tableName;
      const navigation = router.getCurrentNavigation();

      if (navigation) {
        const state = navigation.extras.state;

        if (state) {
          keyValues = state['keyValues'];
          tableName = state['tableName'];
        }
      }

      if (keyValues || tableName) this.serviceFilter = `keyValues="${keyValues}"&tableName="${tableName}`;
    }
  }

  async ngOnInit() {
    var res = await this.api.getTables();
    this.searchDdlFields[0].options = res; /* TABLES FILTER DDL NEEDS TO BE AT ZERO ELEMENT */
  }

  onView(event: any) {
    this.dialog.open(AuditComponent, {
      data: {
        id: event,
      },
      disableClose: true,
      id: 'audit-details',
      width: "80vw",
      height: "40vw",
    });
  }
}
