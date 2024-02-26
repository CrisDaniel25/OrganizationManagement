import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { InputType } from 'src/app/core/enums/input-type.enum';
import { FieldConfig } from 'src/app/shared/interfaces';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.css']
})
export class InputComponent {
  field!: FieldConfig;
  group!: FormGroup;

  constructor() { }

  getInputType(type: string | null | undefined): string {
    return !!type ? type : InputType.TEXT;
  }
}
