import { AfterViewInit, Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild, ViewChildren, QueryList } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import * as _moment from 'moment';
import { AppService } from 'src/app/core/services/app.service';
import { DynamicService } from 'src/app/core/services/dynamic.service';
import { FieldConfig, GridColumns } from '../../interfaces';
import { DateAdapter } from 'angular-calendar';
import { MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { MY_FORMATS } from 'src/app/core/constants/date-formats.constant';
import { MessengerService } from 'src/app/core/services/messenger.service';
import { Subscription } from 'rxjs';
const moment = _moment || '' /*_rollupMoment */;

@Component({
  selector: 'app-dynamic-grid',
  templateUrl: './dynamic-grid.component.html',
  styleUrls: ['./dynamic-grid.component.css'],
  providers: [
    // `MomentDateAdapter` can be automatically provided by importing `MomentDateModule` in your
    // application's root module. We provide it at the component level here, due to limitations of
    // our example generation script.
    /*{
      provide: DateAdapter,
      useClass: MomentDateAdapter,
      deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS],
    },*/
    { provide: MAT_DATE_FORMATS, useValue: MY_FORMATS },
  ],

})
export class DynamicGridComponent implements OnInit, AfterViewInit {
  @Input() parentId: string | number | null = null;
  @Input() parentName: string | null = null;
  /* DATA COLUMNS TO BE DISPLAYED */
  @Input()
  displayedDataColumns: GridColumns[] = [];
  @Input() service: string = '';
  @Input() serviceFilter: string = '';
  @Input() entityView: string = '';
  @Input() title = '';
  /* ACCESS */
  @Input() create: string[] = [];
  @Input() edit: string[] = [];
  @Input() delete: string[] = [];
  @Input() print: string[] = [];
  @Input() log: string[] = [];
  @Input() searchDdlFields: FieldConfig[] = [];
  @Output() onNew = new EventEmitter<string | number>();
  @Output() onEdit = new EventEmitter<string | number>();
  @Output() onDelete = new EventEmitter<string | number>();
  @Output() onView = new EventEmitter<string | number>();
  @Output() onPrint = new EventEmitter<string | number>();
  @Output() onLog = new EventEmitter<string | number>();
  form!: FormGroup;
  /* TOTAL COLUMNS TO BE DISPLAYED IN GRID */
  displayedColumns: string[] = [];
  statusChipList: any[] = [];
  @ViewChild('TABLE') table!: ElementRef;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild('paginator', { static: true }) paginator!: MatPaginator;
  @ViewChild('searchIn', { static: true }) searchIn!: ElementRef;
  @ViewChildren('filterSelect') filterSelect: QueryList<ElementRef> = new QueryList<ElementRef>();
  pageSize = 10;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  pageEvent!: PageEvent;
  public dataSource!: MatTableDataSource<any>;
  /* STORE SELECTED VALUE IN DDL STATUS */
  selectedStatus: any;
  /* STORE THE ID COLUMN NAME */
  idColumnName: string = '';
  createAccess: boolean = false;
  editAccess: boolean = false;
  deleteAccess: boolean = false;
  printAccess: boolean = false;
  logAccess: boolean = false;
  lenght: number = 0;

  notifierSubcrition: Subscription = this.appService.notifierDynamicGrigToUpdateData.subscribe((data) => this.ngAfterViewInit());

  constructor(
    private router: Router,
    private dynamicService: DynamicService,
    private appService: AppService,
    private messengerService: MessengerService,
    private fb: FormBuilder
  ) { }

  async ngOnInit() {
    this.dynamicService.serviceName = this.service;
    this.createAccess = this.appService.checkMenuRoleAccess(this.create)
    this.editAccess = this.appService.checkMenuRoleAccess(this.edit)
    this.deleteAccess = this.appService.checkMenuRoleAccess(this.delete)
    this.printAccess = this.appService.checkMenuRoleAccess(this.print)
    this.logAccess = this.appService.checkMenuRoleAccess(this.log)
    /* GET ALL COLUMNS */
    this.displayedColumns = Object.assign(
      [],
      this.displayedDataColumns.map((e) => {
        return e.name;
      })
    );
    /* PUSH ACTION COLUMN */
    this.displayedColumns.push('action');
    /* GET NAME OF COLUMN ID */
    var columns = this.displayedDataColumns.filter((s) => s.isId);
    if (columns.length == 1) {
      this.idColumnName = columns[0].name;
    }
    /* SET STATUS CHIP OPTIONS */
    this.searchDdlFields.forEach((field) => {
      field.options?.forEach((opt: any, i: number) => {
        if (!this.statusChipList.some((c) => c.desc === opt.description))
          if (i > 0) this.statusChipList.push(opt);
      });
    });
    this.form = this.createControl();
  }

  ngAfterViewInit() {
    this.appService.loading = true;
    if (!this.parentId && !this.parentName) {
      this.dynamicService.get(this.serviceFilter).subscribe(
        (res: any) => {
          this.lenght = res.length;
          this.dataSource = new MatTableDataSource();
          this.dataSource.filterPredicate = this.filterPredicate();
          this.dataSource.data = res;
          this.dataSource.paginator = this.paginator;
          this.dataSource.sort = this.sort;
          this.appService.loading = false;
        },
        (error: any) => {
          this.appService.loading = false;
          this.messengerService.addMessage(error);
        }
      );
    } else if (this.parentId && this.parentName) {
      this.dynamicService.getChildList(this.parentId, this.parentName).subscribe(
        (res: any) => {
          this.lenght = res.length;
          this.dataSource = new MatTableDataSource();
          this.dataSource.filterPredicate = this.filterPredicate();
          this.dataSource.data = res;
          this.dataSource.paginator = this.paginator;
          this.dataSource.sort = this.sort;
          this.appService.loading = false;
        },
        (error: any) => {
          this.appService.loading = false;
          this.messengerService.addMessage(error);
        }
      );
    }
  }

  goToNew() {
    if (this.entityView && !this.parentName) {
      this.router.navigate([`/home/${this.entityView}`]);
    } else if (this.entityView && this.parentName) {
      this.router.navigate([`/home/${this.parentName}/${this.parentId}/${this.entityView}`]);
    }
    else {
      this.onNew.emit();
    }
  }

  goToEdit(id: string | number) {
    if (this.entityView && !this.parentName) {
      this.router.navigate([`/home/${this.entityView}`, id]);
    } else if (this.entityView && this.parentName) {
      this.router.navigate([`/home/${this.parentName}/${this.parentId}/${this.entityView}`, id]);
    }
    else {
      this.onEdit.emit(id);
    }
  }

  goToDelete(id: string | number) {
    if (this.entityView && !this.parentName) {
      this.router.navigate([`/home/${this.entityView}`, id, 'delete']);
    } else if (this.entityView && this.parentName) {
      this.router.navigate([`/home/${this.parentName}/${this.parentId}/${this.entityView}`, id, 'delete']);
    }
    else {
      this.onDelete.emit(id);
    }
  }

  goToView(id: string | number) {
    if (this.entityView && !this.parentName) {
      this.router.navigate([`/home/${this.entityView}/${id}/view`]);
    } else if (this.entityView && this.parentName) {
      this.router.navigate([`/home/${this.parentName}/${this.parentId}/${this.entityView}/${id}/view`]);
    }
    else {
      this.onView.emit(id);
    }
  }

  goToPrint(id: string | number) {
    this.onPrint.emit(id);
  }

  goToLog(id: string | number) {
    this.onLog.emit(id);
  }

  doFilter() {
    this.dataSource.filter = '';
    this.dataSource.filter =
      this.searchIn.nativeElement.value.toString().trim().toLowerCase() + '$';
    if (this.filterSelect['_results']) {
      this.filterSelect['_results'].map((f: any) => {
        const value = f.nativeElement ? f.nativeElement.value : f.value;
        if (value !== undefined && value !== '') {
          this.dataSource.filter += value.toString().trim().toLowerCase() + '$';
        }
      });
    }
  }

  filterPredicate(): any {
    return (row: any, filters: string) => {
      /* split string per '$' to array */
      const search = filters.split('$');
      search.pop(); // removes empty search element
      const matchFilter = [];
      /* verify fetching data by our searching values */
      if (search[0] != '') {
        matchFilter.push(
          this.displayedDataColumns
            .filter((s) => !s.searchFields)
            .some((x) => {
              return row[x.name]
                ?.toString()
                .trim()
                .toLowerCase()
                .includes(search[0].toString().trim().toLowerCase());
            })
        );
      }

      search.map((x, i) => {
        if (i > 0) {
          matchFilter.push(
            this.displayedDataColumns
              .filter(
                (s) => (s.searchFields || s.isDate || s.isTime) && !s.isId
              )
              .some((x) => {
                return row[x.name]
                  ?.toString()
                  .trim()
                  .toLowerCase()
                  .includes(search[i].toString().trim().toLowerCase());
              })
          );
        }
      });

      return matchFilter.every(Boolean);
    };
  }

  setPageSizeOptions(setPageSizeOptionsInput: string) {
    if (setPageSizeOptionsInput) {
      this.pageSizeOptions = setPageSizeOptionsInput
        .split(',')
        .map((str) => +str);
    }
  }

  createControl() {
    const group = this.fb.group({});
    this.searchDdlFields.forEach((field: FieldConfig) => {
      let control;
      if (field.isDate) control = this.fb.control(moment());
      else control = this.fb.control(null);
      group.addControl(field.name, control);
    });
    return group;
  }
}
