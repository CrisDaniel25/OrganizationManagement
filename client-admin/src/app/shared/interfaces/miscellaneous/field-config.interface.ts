import { PipeTransform } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import { Observable } from 'rxjs';
import { FieldType } from 'src/app/core/enums/field-type.enum';
import { InputType } from 'src/app/core/enums/input-type.enum';

export interface Validator {
    name: string;
    validator: any;
    message: string;
}

export interface Options {
    id: string | number | object | null | undefined | any;
    desc: string | number | object | null | undefined | any;
    isOn?: boolean;
}

export interface FieldConfig {
    label: string;
    name: string;
    nameTwo?: string;
    inputType?: InputType;
    options?: Options[];
    observableOptions?: Observable<Options[]>;
    collections?: any;
    type?: FieldType;
    value?: any;
    validations?: Validator[];
    icon?: string;
    classes?: string[];
    color?: ThemePalette;
    visible?: boolean;
    isDate?: boolean;
    disabled?: boolean;
    pipe?: PipeTransform;
    dataType?: string;
    pristine?: boolean;
    returnPath?: string;
}

