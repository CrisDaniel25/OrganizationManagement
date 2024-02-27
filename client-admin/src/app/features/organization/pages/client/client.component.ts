import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { MenuRoles } from 'src/app/core/constants/menu-roles.constant';
import { FieldType } from 'src/app/core/enums/field-type.enum';
import { InputType } from 'src/app/core/enums/input-type.enum';
import { FieldLayout } from 'src/app/shared/interfaces';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent implements OnInit {
  title: string = this.translate.instant('client.title');
  serviceName: string = 'clients';

  tabTitle: string = this.translate.instant('employee.title');

  id: string | null = null;
  height: string = '25vw';
  width: string = '80vw';

  create: string[] = MenuRoles.CLIENTS_CREATE;
  edit: string[] = MenuRoles.CLIENTS_UPDATE;

  fields: FieldLayout[] = [
    {
      parentClass: ['row'],
      fields: [
        {
          classes: ['col-3'],
          label: 'client.name',
          type: FieldType.INPUT,
          inputType: InputType.TEXT,
          name: 'Name',
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
          label: 'client.email',
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
          label: 'client.phone',
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
          label: 'client.website',
          type: FieldType.INPUT,
          inputType: InputType.TEL,
          name: 'Website',
          validations: [
            {
              name: '',
              message: '',
              validator: Validators.required
            }
          ],
          visible: true
        },
      ]
    },
    {
      parentClass: ['row'],
      fields: [
        {
          classes: ['col-3'],
          label: 'client.industry',
          type: FieldType.INPUT,
          inputType: InputType.TEXT,
          name: 'Industry',
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
          label: 'client.headquarters',
          type: FieldType.INPUT,
          inputType: InputType.TEXT,
          name: 'Headquarters',
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
          label: 'client.company-size',
          type: FieldType.INPUT,
          inputType: InputType.NUMBER,
          name: 'CompanySize',
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
          label: 'client.founded',
          type: FieldType.DATE,
          inputType: InputType.DATE,
          name: 'Founded',
          validations: [
            {
              name: '',
              message: '',
              validator: Validators.required
            }
          ],
          visible: true
        },
      ]
    },
    {
      parentClass: ['row'],
      fields: [
        {
          classes: ['col'],
          name: 'submit',
          label: 'client.submit',
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

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id') || null;
  }

  onClose(event: Event): void {
    this.goBack();
  }

  goBack(): void {
    this.router.navigate(['/home/client-list']);
  }
}
