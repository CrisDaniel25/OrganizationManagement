import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FieldConfig, FieldLayout } from '../../interfaces';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AppService } from 'src/app/core/services/app.service';
import { DynamicService } from 'src/app/core/services/dynamic.service';
import { distinctUntilChanged } from 'rxjs/operators';
import { MessengerService } from 'src/app/core/services/messenger.service';
import { FieldType } from 'src/app/core/enums/field-type.enum';

@Component({
  selector: 'app-dynamic-form',
  templateUrl: './dynamic-form.component.html',
  styleUrls: ['./dynamic-form.component.css']
})
export class DynamicFormComponent implements OnInit {
  @Input() fields: FieldLayout[] = [];
  @Input() title!: string;
  @Input() subtitle!: string;
  @Input() id!: string | number | null;
  @Input() height: string = "auto";
  @Input() width: string = "auto";
  @Input() service!: string;
  @Input() edit!: string[];
  @Input() create!: string[];

  @Output() submit: EventEmitter<any> = new EventEmitter<any>();
  @Output() onAfterLoadData: EventEmitter<any> = new EventEmitter();
  @Output() onChange: EventEmitter<any> = new EventEmitter();

  form: FormGroup = new FormGroup({});
  readOnly: boolean = false;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private appService: AppService,
    private dynamicService: DynamicService,
    private messengerService: MessengerService
  ) { }

  async ngOnInit() {
    try {
      this.dynamicService.serviceName = this.service;
      this.readOnly =
        !(this.appService.checkMenuRoleAccess(this.edit) &&
          this.appService.checkMenuRoleAccess(this.create));

      this.appService.loading = true;
      this.id = this.id || this.route.snapshot.paramMap.get('id') || null;
      this.form = this.createControl();

      if (this.id) {
        if (!this.subtitle) this.subtitle = `#${this.id}`;
        const res: any = await this.dynamicService.getById(this.id);
        if (res) {
          this.form.patchValue(res);
          this.onAfterLoadData.emit(res);
        }
      } else {
        this.route.queryParams.subscribe((params) => {
          if (params['data']) {
            this.form.patchValue(JSON.parse(params['data']));
            this.onAfterLoadData.emit(JSON.parse(params['data']));
          }
        });
      }

      if (this.readOnly) this.form.disable();

      this.appService.loading = false;
    } catch (error: any) {
      this.appService.loading = false;
      this.messengerService.addMessage(error)
    }
  }

  async onSubmit(event: Event) {
    try {
      event.preventDefault();
      event.stopPropagation();
      if (this.form.valid) {
        this.appService.loading = true;
        if (this.service) {
          if (this.id) {
            const res: any = await this.dynamicService.put(this.id, this.form.getRawValue());
            this.submit.emit(res);
            this.appService.notifierDynamicGrigToUpdateData.next(res);
          } else {
            const res: any = await this.dynamicService.post(this.form.getRawValue());
            this.submit.emit(res);
            this.appService.notifierDynamicGrigToUpdateData.next(res);
          }
        }
        this.appService.loading = false;
      } else {
        this.validateAllFormFields(this.form);
      }
    } catch (error: any) {
      this.appService.loading = false;
      this.messengerService.addMessage(error)
    }
  }

  createControl() {
    const group = this.fb.group({}), fieldControls: FieldConfig[] = [];
    this.fields.map((field) => { field.fields.map((value) => { fieldControls.push(value) }) });
    fieldControls.forEach((field) => {
      if (field.type === FieldType.BUTTON) {
        field.visible = !this.readOnly;
        return;
      }

      const control = this.fb.control(
        { value: field.value, disabled: field.disabled },
        this.bindValidations(field.validations || [])
      );

      control.valueChanges.pipe(distinctUntilChanged()).subscribe((val) => {
        if (field.pipe) {
          const maskedVal = field.pipe.transform(val);
          control.patchValue(maskedVal);
        }
        this.onChange.emit({ name: field.name, value: control.value });
      });

      group.addControl(field.name, control);

      if (field.type === FieldType.DATE_RANGE) {
        const control = this.fb.control(
          { value: field.value, disabled: field.disabled },
          this.bindValidations(field.validations || [])
        );

        control.valueChanges.pipe(distinctUntilChanged()).subscribe((val) => {
          if (field.pipe) {
            const maskedVal = field.pipe.transform(val);
            control.patchValue(maskedVal);
          }
          this.onChange.emit({ name: field.name, value: control.value });
        });

        group.addControl(field.nameTwo || '', control);
      }
    });

    return group;
  }

  bindValidations(validations: any) {
    if (validations.length > 0) {
      const validList: any[] = [];

      validations.forEach((valid: any) => {
        validList.push(valid.validator);
      });

      return Validators.compose(validList);
    }

    return null;
  }

  validateAllFormFields(formGroup: FormGroup) {
    Object.keys(formGroup.controls).forEach((field) => {
      const control: any = formGroup.get(field);
      control.markAsTouched({ onlySelf: true });
    });
  }

  getFullMergedParentClass(parentClass: string[]) {
    return parentClass.join(' ');
  }
}
