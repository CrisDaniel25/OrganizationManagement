import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FieldConfig } from 'src/app/shared/interfaces';

@Component({
  selector: 'app-select-with-api-result',
  templateUrl: './select-with-api-result.component.html',
  styleUrls: ['./select-with-api-result.component.css']
})
export class SelectWithApiResultComponent {
  field!: FieldConfig;
  group!: FormGroup;
}
