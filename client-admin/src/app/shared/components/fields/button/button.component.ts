import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { InputType } from 'src/app/core/enums/input-type.enum';
import { FieldConfig } from 'src/app/shared/interfaces';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.css']
})
export class ButtonComponent {
  field!: FieldConfig;
  group!: FormGroup;

  getInputType(type: string | null | undefined): string {
    return !!type ? type : InputType.BUTTON;
  }
}
