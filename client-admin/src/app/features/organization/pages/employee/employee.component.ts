import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { MenuRoles } from 'src/app/core/constants/menu-roles.constant';
import { FieldType } from 'src/app/core/enums/field-type.enum';
import { InputType } from 'src/app/core/enums/input-type.enum';
import { FieldLayout } from 'src/app/shared/interfaces';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent {
  title: string = this.translate.instant('employee.title');
  serviceName: string = 'employees';

  id: string | null = null;
  height: string = '35vw';
  width: string = '85vw';

  create: string[] = MenuRoles.EMPLOYEES_CREATE;
  edit: string[] = MenuRoles.EMPLOYEES_UPDATE;

  fields: FieldLayout[] = [
    {
      parentClass: ['row'],
      fields: [
        {
          classes: ['col-3'],
          label: 'employee.identity-document',
          name: 'IdentityDocument',
          type: FieldType.INPUT,
          inputType: InputType.TEXT,
          validations: [
            {
              name: '',
              message: '',
              validator: Validators.required
            }
          ],
          visible: true
        },
        {
          classes: ['col-3'],
          label: 'employee.first-name',
          type: FieldType.INPUT,
          inputType: InputType.TEXT,
          name: 'FirstName',
          validations: [
            {
              name: '',
              message: '',
              validator: Validators.required
            }
          ],
          visible: true
        },
        {
          classes: ['col-3'],
          label: 'employee.middle-name',
          type: FieldType.INPUT,
          inputType: InputType.TEXT,
          name: 'MiddleName',
          validations: [
          ],
          visible: true
        },
        {
          classes: ['col-3'],
          label: 'employee.last-name',
          type: FieldType.INPUT,
          inputType: InputType.TEXT,
          name: 'LastName',
          validations: [
            {
              name: '',
              message: '',
              validator: Validators.required
            }
          ],
          visible: true
        }
      ]
    },
    {
      parentClass: ['row'],
      fields: [
        {
          classes: ['col-3'],
          label: 'employee.email',
          type: FieldType.INPUT,
          inputType: InputType.EMAIL,
          name: 'Email',
          validations: [
            {
              name: '',
              message: '',
              validator: Validators.required
            }
          ],
          visible: true
        },
        {
          classes: ['col-3'],
          label: 'employee.phone',
          type: FieldType.INPUT,
          inputType: InputType.TEL,
          name: 'Phone',
          validations: [
            {
              name: '',
              message: '',
              validator: Validators.required
            }
          ],
          visible: true
        },
        {
          classes: ['col-3'],
          label: 'employee.gender',
          type: FieldType.SELECT,
          options: [
            {
              id: 'M',
              desc: 'employee.masculine',
              isOn: true
            },
            {
              id: 'F',
              desc: 'employee.female'
            }
          ],
          name: 'Gender',
          visible: true
        },
        {
          classes: ['col-3'],
          label: 'employee.birth-date',
          name: 'BirthDate',
          inputType: InputType.DATE,
          type: FieldType.DATE,
          validations: [
            {
              name: '',
              message: '',
              validator: Validators.required
            }
          ],
          visible: true
        }
      ]
    },
    {
      parentClass: ['row'],
      fields: [
        {
          classes: ['col-2'],
          label: 'employee.start-date',
          name: 'StartDate',
          validations: [
            {
              name: '',
              message: '',
              validator: Validators.required
            }
          ],
          type: FieldType.DATE,
          inputType: InputType.DATE,
          visible: true
        },
        {
          classes: ['col-2'],
          label: 'employee.end-date',
          name: 'EndDate',
          validations: [],
          type: FieldType.DATE,
          inputType: InputType.DATE,
          visible: true
        },
        {
          classes: ['col-3'],
          label: 'employee.department',
          name: 'Department',
          type: FieldType.INPUT,
          inputType: InputType.TEXT,
          visible: true
        },
        {
          classes: ['col-3'],
          label: 'employee.position',
          name: 'Position',
          type: FieldType.INPUT,
          inputType: InputType.TEXT,
          visible: true
        },
        {
          classes: ['col-2'],
          label: 'employee.is-active',
          name: 'IsActive',
          type: FieldType.CHECK_BOX,
          inputType: InputType.CHECKBOX,
          visible: true
        }
      ]
    },
    {
      parentClass: ['row'],
      fields: [
        {
          classes: ['col'],
          name: 'submit',
          label: 'employee.submit',
          color: 'primary',
          type: FieldType.BUTTON,
          inputType: InputType.SUBMIT,
          disabled: false,
          visible: true,
        }
      ]
    },
    {
      parentClass: ['row'],
      fields: [
        {
          label: '',
          name: 'ClientId',
          visible: false,
          value: this.route.snapshot.paramMap.get('clientId')
        },
        {
          label: '',
          name: 'CreatedUser',
          visible: false
        },
        {
          label: '',
          name: 'CreatedDate',
          visible: false
        },
        {
          label: '',
          name: 'UpdatedUser',
          visible: false
        },
        {
          label: '',
          name: 'UpdatedDate',
          visible: false
        }
      ]
    },
  ]

  constructor(private router: Router, private route: ActivatedRoute, private readonly translate: TranslateService) { }

  onClose(event: Event): void {
    this.goBack();
  }

  goBack(): void {
    this.router.navigate(['/home/client', this.route.snapshot.paramMap.get('clientId')]);
  }
}
