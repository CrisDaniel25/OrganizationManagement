import { Component, OnInit, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppService } from 'src/app/core/services/app.service';
import { MessengerService } from 'src/app/core/services/messenger.service';
import { AuditService } from '../../services/audit.service';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-audit',
  templateUrl: './audit.component.html',
  styleUrls: ['./audit.component.css']
})
export class AuditComponent implements OnInit {
  id: string = '';
  dataObject: any = {};

  operation: string = '';
  tableName: string = '';

  showTextDiff: boolean = false;

  constructor(
    private appService: AppService,
    private auditService: AuditService,
    private route: ActivatedRoute,
    private messengerService: MessengerService,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }

  async ngOnInit() {
    try {
      this.appService.loading = true;
      this.id = this.data['id'] || this.route.snapshot.paramMap.get('id');
      if (this.id) {
        this.appService.loading = true;
        const res = await this.auditService.getById(this.id);
        this.dataObject = {
          data: {
            tableName: res.TableName,
            dateTime: res.DateTime,
            date: res.Date,
            keyValues: res.KeyValues,
            operation: res.Operation || '',
            changeBy: res.ChangeBy
          },
          left: res.OldValues ? res.OldValues.replaceAll(',"', ',"\n') : '',
          right: res.NewValues ? res.NewValues.replaceAll(',"', ',"\n') : '',
        };
        this.operation = res.Operation;
        this.tableName = res.TableName;
      }
      this.showTextDiff = true;
      this.appService.loading = false;
    } catch (error: any) {
      this.appService.loading = false;
      this.messengerService.addMessage(error)
    }
  }

}
