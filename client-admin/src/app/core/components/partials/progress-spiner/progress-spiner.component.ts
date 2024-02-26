import { Component, AfterContentChecked } from '@angular/core';
import { ProgressSpinnerMode } from '@angular/material/progress-spinner';
import { AppService } from 'src/app/core/services/app.service';

@Component({
  selector: 'app-progress-spiner',
  templateUrl: './progress-spiner.component.html',
  styleUrls: ['./progress-spiner.component.css']
})
export class ProgressSpinerComponent implements AfterContentChecked {

  hidden: boolean = false;

  mode: ProgressSpinnerMode = 'indeterminate';

  constructor(public appService: AppService) { }

  ngAfterContentChecked(): void {
    this.hidden = !this.appService.loading;
  }
}
